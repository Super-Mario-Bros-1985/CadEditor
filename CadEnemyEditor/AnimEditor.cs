﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using CadEditor;
using PluginAnimEditor;

namespace CadEnemyEditor
{
    public partial class AnimEditor : Form
    {
        public AnimEditor()
        {
            InitializeComponent();
        }

        //byte[] Globals.romdata = null;
        AnimData[] animList;
        FrameData[] frameList;
        CoordData[] coordList;

        FrameData activeFrame;

        byte[] pal = new byte[16];
        byte[] pal0 = AnimConfig.pal;

        private void loadData()
        {
            loadAnimData();

            //test fill pal
            for (int i = 0; i < 16; i++)
                pal[i] = pal0[i];
        }

        private void loadAnimData()
        {
            int ANIM_COUNT = AnimConfig.ANIM_COUNT;
            int animAddrHi = AnimConfig.animAddrHi;
            int animAddrLo = AnimConfig.animAddrLo;

            int FRAME_COUNT = AnimConfig.FRAME_COUNT;
            int frameAddr1Hi = AnimConfig.frameAddrHi;
            int frameAddr1Lo = AnimConfig.frameAddrLo;

            int COORD_COUNT = AnimConfig.COORD_COUNT;
            int coordAddrHi = AnimConfig.coordAddrHi;
            int coordAddrLo = AnimConfig.coordAddrLo;

            animList = new AnimData[ANIM_COUNT];
            frameList = new FrameData[FRAME_COUNT];
            coordList = new CoordData[COORD_COUNT];

            for (int i = 0; i < ANIM_COUNT; i++)
            {
                byte hiAddrByte = Globals.romdata[animAddrHi + i];
                byte loAddrByte = Globals.romdata[animAddrLo + i];
                int addr = Utils.makeAddrPtr(hiAddrByte, loAddrByte);
                int addrRom = Utils.getCapcomAnimAddr(AnimConfig.animBankNo, addr);
                int frameCountAndShift = Globals.romdata[addrRom] + 1;
                int framesCount = frameCountAndShift % 128;
                int frameShift = frameCountAndShift < 128 ? 0 : 256;
                int timer = Globals.romdata[addrRom+1];
                int[] frameIndexes = null;
                {
                    frameIndexes = new int[framesCount];
                    for (int frame = 0; frame < framesCount; frame++)
                    {
                        int frameNo = Globals.romdata[addrRom + 2 + frame];
                        frameIndexes[frame] = frameNo + frameShift;
                    }
                }
                animList[i] = new AnimData(i, addr, framesCount, timer, frameIndexes, frameShift);
            }

            for (int frame = 0; frame < FRAME_COUNT; frame++)
            {
                byte frameAddrHi = Globals.romdata[frameAddr1Hi + frame];
                byte frameAddrLo = Globals.romdata[frameAddr1Lo + frame];
                int frameAddr = Utils.makeAddrPtr(frameAddrHi, frameAddrLo);
                int frameAddrRom = Utils.getCapcomAnimAddr(AnimConfig.animBankNo, frameAddr);
                int tileCount = Globals.romdata[frameAddrRom]+1;
                int coordsIndex = Globals.romdata[frameAddrRom+1];
                var tiles = new TileInfo[tileCount];
                for (int tile = 0; tile < tileCount; tile++)
                {
                    tiles[tile].index    = Globals.romdata[frameAddrRom + 2 + tile*2];
                    tiles[tile].property = Globals.romdata[frameAddrRom + 2 + tile*2+1];
                }
                FrameData frameData = new FrameData(frame, frameAddr, tileCount, coordsIndex, tiles);
                frameList[frame] = frameData;
            }

            for (int coord = 0; coord < COORD_COUNT; coord++)
            {
                byte coordAddrHiByte = Globals.romdata[coordAddrHi + coord];
                byte coordAddrLoByte = Globals.romdata[coordAddrLo + coord];
                int coordAddr = Utils.makeAddrPtr(coordAddrHiByte, coordAddrLoByte);
                CoordData coordData = new CoordData(coordAddr);
                coordList[coord] = coordData;
            }

            mapAnimToTreeView();
        }

        private void mapAnimToTreeView()
        {
            TreeNode root = new TreeNode("Root");
            for (int i = 0; i < animList.Count(); i++)
            {
                TreeNode animNode = new TreeNode(animList[i].ToString());
                root.Nodes.Add(animNode);
                var fl = animList[i].frameList;
                if (fl == null)
                    continue;
                for (int f = 0; f < animList[i].framesCount; f++)
                {
                    TreeNode frameNode = new TreeNode(frameList[fl[f]].ToString());
                    frameNode.Tag = frameList[fl[f]];
                    animNode.Nodes.Add(frameNode);
                }
            }
            tvAnims.Nodes.Add(root);
        }

        private void reloadVideo(int index)
        {
            int videoId = index;
            var videoChunk = ConfigScript.getVideoChunk(videoId);
            var videoStrip = ConfigScript.videoNes.makeImageStrip(videoChunk, pal, 0, true);
            Bitmap resultVideo = new Bitmap(256, 256);
            using (Graphics g = Graphics.FromImage(resultVideo))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                for (int i = 0; i < 256; i++)
                {
                    g.DrawImage(videoStrip, new Rectangle(i % 16 * 16, (i / 16) * 16, 16, 16), new Rectangle(i * 8, 0, 8, 8), GraphicsUnit.Pixel);
                }
            }
            pbVideo.Image = resultVideo;

            //
            imageList1.Images.Clear();
            imageList2.Images.Clear();
            imageList3.Images.Clear();
            imageList4.Images.Clear();
            imageList1.Images.AddStrip(videoStrip);
            imageList2.Images.AddStrip(ConfigScript.videoNes.makeImageStrip(videoChunk, pal, 1, true));
            imageList3.Images.AddStrip(ConfigScript.videoNes.makeImageStrip(videoChunk, pal, 2, true));
            imageList4.Images.AddStrip(ConfigScript.videoNes.makeImageStrip(videoChunk, pal, 3, true));

            setPal();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            reloadVideo(0);
            cbVideo.SelectedIndex = 0;
        }

        private void drawFrame(FrameData f, bool drawWithSelectedTiles = false)
        {
            if (f == null)
                return;
            int scale = 4;
            Bitmap frame = new Bitmap(128 * scale, 128 * scale);

            int count = f.tileCount;
            TileInfo[] tiles = f.tiles;
            int coordsAddr = coordList[f.coordsIndex].addr;
            int coordsRomAddr = Utils.getCapcomAnimAddr(AnimConfig.animBankNo, coordsAddr);
            int addPart = (128 / 2 * scale);

            ImageList[] imageLists = { imageList1, imageList2, imageList3, imageList4 };

            using (Graphics g = Graphics.FromImage(frame))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.FillRectangle(Brushes.Black, new Rectangle(0,0,128*scale, 128*scale));
                for (int i = 0; i < count; i++)
                {
                    byte xcByte = Globals.romdata[coordsRomAddr + i * 2 + 1];
                    byte ycByte = Globals.romdata[coordsRomAddr + i * 2 + 0];
                    int xOrig = Utils.getSignedFromByte(xcByte);
                    int yOrig = Utils.getSignedFromByte(ycByte);
                    int x = addPart + xOrig * scale;
                    int y = addPart + yOrig * scale;
                    int index = tiles[i].index;
                    int property = tiles[i].property;
                    int xh = x + 8 * scale;
                    int yh = y + 8 * scale;
                    int subPalIndex = property & 0x3;

                    Point[] destPoints = new Point[3];
                    bool xReverted = (property & 0x40) == 0x40;
                    bool yReverted = (property & 0x80) == 0x80;
                    destPoints[0] = new Point(xReverted ? xh : x, yReverted ? yh : y);
                    destPoints[1] = new Point(xReverted ? x : xh, yReverted ? yh : y);
                    destPoints[2] = new Point(xReverted ? xh : x, yReverted ? y : yh);
                    g.DrawImage(imageLists[subPalIndex].Images[index], destPoints/*, new Rectangle(addPart + xs[i]*scale, addPart + ys[i]*scale, 8 * scale, 8 * scale)*/);
                    if (drawWithSelectedTiles)
                    {
                        if (lvTiles.SelectedIndices.Contains(i))
                          g.DrawRectangle(new Pen(Brushes.Red, 2.0f), new Rectangle(destPoints[0].X, destPoints[0].Y, 8 * scale, 8 * scale));
                    }
                }
            }
            pbFrame.Image = frame;
        }

        private void tvAnims_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            if (node.Tag != null)
            {
                activeFrame = (FrameData)node.Tag;
                drawFrame(activeFrame);
                setTiles(activeFrame);
            }
        }

        private void setTiles(FrameData f)
        {
            lvTiles.Items.Clear();
            TileInfo[] tiles = f.tiles;
            int coordsAddr = coordList[f.coordsIndex].addr;
            int coordsRomAddr = Utils.getCapcomAnimAddr(AnimConfig.animBankNo, coordsAddr);
            for (int i = 0; i < tiles.Length; i++)
            {
                byte xcByte = Globals.romdata[coordsRomAddr + i * 2 + 1];
                byte ycByte = Globals.romdata[coordsRomAddr + i * 2 + 0];
                lvTiles.Items.Add(String.Format("T:{0,2:X2} P[{1,2:X2}] X:{2,2:X2} Y:{3,2:X2}", tiles[i].index, tiles[i].property, xcByte, ycByte));
            }
        }

        private void cbVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbVideo.SelectedIndex - 0x10;
            reloadVideo(index);
            drawFrame(activeFrame);
        }

        void flushToFile()
        {
            Globals.flushToFile();
        }

        private void pbVideo_MouseClick(object sender, MouseEventArgs e)
        {
            if (activeFrame == null)
                return;
            int xNo = e.X / 16;
            int yNo = e.Y / 16;
            int tileNo = yNo * 16 + xNo;

            var tileIndexes = lvTiles.SelectedIndices;
            for (int ti = 0; ti < tileIndexes.Count; ti++)
                activeFrame.tiles[tileIndexes[ti]].index = tileNo;
            drawFrame(activeFrame);
        }

        private void cbFlipX_CheckedChanged(object sender, EventArgs e)
        {
            if (activeFrame == null)
                return;
            int flipYByte = cbFlipY.Checked ? 0x80 : 0;
            int flipXByte = cbFlipX.Checked ? 0x40 : 0;
            var tileIndexes = lvTiles.SelectedIndices;
            for (int ti = 0; ti < tileIndexes.Count; ti++)
            {
                int p = activeFrame.tiles[tileIndexes[ti]].property;
                p = p & 0x7F | flipYByte;
                p = p & 0xBF | flipXByte;
                activeFrame.tiles[tileIndexes[ti]].property = p;
            }
            drawFrame(activeFrame);
        }

        private void cbTileIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activeFrame == null)
                return;
            int pal = cbTileIndex.SelectedIndex;
            var tileIndexes = lvTiles.SelectedIndices;
            for (int ti = 0; ti < tileIndexes.Count; ti++)
            {
                int p = activeFrame.tiles[tileIndexes[ti]].property;
                p = p & 0xFC | pal;
                activeFrame.tiles[tileIndexes[ti]].property = p;
            }
            drawFrame(activeFrame);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int FRAME_COUNT = AnimConfig.FRAME_COUNT;
            int frameAddr1Hi = AnimConfig.frameAddrHi;
            int frameAddr1Lo = AnimConfig.frameAddrLo;


            for (int frame = 0; frame < FRAME_COUNT; frame++)
            {
                byte frameAddrHi = Globals.romdata[frameAddr1Hi + frame];
                byte frameAddrLo = Globals.romdata[frameAddr1Lo + frame];
                int frameAddr = Utils.makeAddrPtr(frameAddrHi, frameAddrLo);
                int frameAddrRom = Utils.getCapcomAnimAddr(AnimConfig.animBankNo, frameAddr);
                int tileCount = Globals.romdata[frameAddrRom] + 1;
                int coordsIndex = Globals.romdata[frameAddrRom + 1];
                var tiles = frameList[frame].tiles;
                for (int tile = 0; tile < tileCount; tile++)
                {
                    Globals.romdata[frameAddrRom + 2 + tile * 2] = (byte)tiles[tile].index;
                    Globals.romdata[frameAddrRom + 2 + tile * 2 + 1] = (byte)tiles[tile].property;
                }
                FrameData frameData = new FrameData(frame, frameAddr, tileCount, coordsIndex, tiles);
                frameList[frame] = frameData;
            }

            flushToFile();
        }

        private void lvTiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawFrame(activeFrame, true);
        }

        private void pbPal_MouseClick(object sender, MouseEventArgs e)
        {
           /* var f = new EditColor();
            f.ShowDialog();
            if (EditColor.ColorIndex != -1)
            {
                int index = e.X / 32 + (e.Y / 32) * 4;
                pal[index] = (byte)EditColor.ColorIndex;
                int videoIndex = cbVideo.SelectedIndex;
                reloadVideo(videoIndex);
            }*/
        }

        private void setPal()
        {
            var palImage = new Bitmap(128, 128);
            using (Graphics g = Graphics.FromImage(palImage))
            {
                for (int i = 0; i < 16; i++)
                {
                    g.FillRectangle(new SolidBrush(ConfigScript.videoNes.NesColors[pal[i]]), i % 4 * 32, (i / 4) * 32, 32, 32);
                }
            }
            pbPal.Image = palImage;
        }
    }

    class AnimData
    {
        public AnimData(int no, int addr, int framesCount, int timer, int[] frameList, int frameShift)
        {
            this.no = no;
            this.framesCount = framesCount;
            this.timer = timer;
            this.addr = addr;
            this.frameList = frameList;
            this.frameShift = frameShift;
        }
        public int no;
        public int addr;
        public int framesCount;
        public int timer;
        public int frameShift;
        public int[] frameList;

        public override string ToString()
        {
            return String.Format("A-{0,2:X2}[{1,4:X4}]:(C:{2,3}, T:{3,3}, s:{4})", no, addr, framesCount, timer, frameShift);
        }
    }

    class FrameData
    {
        public FrameData(int frameNo, int frameAddr, int tileCount, int coordsIndex, TileInfo[] tiles)
        {
            this.frameNo = frameNo;
            this.frameAddr = frameAddr;
            this.tileCount = tileCount;
            this.coordsIndex = coordsIndex;
            this.tiles = tiles;
        }
        public int frameNo;
        public int frameAddr;
        public int tileCount;
        public int coordsIndex;
        public TileInfo[] tiles;

        public override string ToString()
        {
            return String.Format("F-{0,2:X2}[{1,4:X4}]:(tC:{2,3}, XYi:{3,2:X2})", frameNo, frameAddr, tileCount, coordsIndex);
        }
    }

    class CoordData
    {
        public CoordData(int addr)
        {
            this.addr = addr;
        }
        public int addr;
    }

    struct TileInfo
    {
        public TileInfo(int index, int property)
        {
            this.index = index;
            this.property = property;
        }

        public int index;
        public int property;
    }
}