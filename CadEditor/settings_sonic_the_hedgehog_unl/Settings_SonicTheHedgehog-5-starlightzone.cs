using CadEditor;
using System;
using System.Drawing;

public class Data 
{ 
  public OffsetRec getScreensOffset() { return new OffsetRec(0x10010, 64, 16*16); }
  public int getScreenWidth()         { return 16; }
  public int getScreenHeight()        { return 16; }
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return getVideoAddress; }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return getVideoChunk;   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x18010, 1  , 0x1000);  }
  public int getBlocksCount()           { return 256; }
  public int getBigBlocksCount()        { return 256; }
  
  public GetBlocksFunc        getBlocksFunc() { return getBlocks;}
  public SetBlocksFunc        setBlocksFunc() { return setBlocks;}
  public GetPalFunc           getPalFunc()           { return getPallete;}
  public SetPalFunc           setPalFunc()           { return null;}
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 2   , 0x1000);  }
  
  //----------------------------------------------------------------------------
  public ObjRec[] getBlocks(int tileId)
  {
    return Utils.readBlocksFromAlignedArrays(Globals.romdata, ConfigScript.getTilesAddr(tileId), ConfigScript.getBlocksCount(), false);
  }
  
  public void setBlocks(int tileId, ObjRec[] blocks)
  {
    Utils.writeBlocksToAlignedArrays(blocks, Globals.romdata, ConfigScript.getTilesAddr(tileId), ConfigScript.getBlocksCount(), true, false);
  }
  
  public byte[] getPallete(int palId)
  {
      return Utils.readBinFile("pal5-1.bin");
  }
  
  public int getVideoAddress(int id)
  {
    return -1;
  }
  
  public byte[] getVideoChunk(int videoPageId)
  {
     if (videoPageId == 0)
     {
        return Utils.readVideoBankFromFile("chr5-1(a).bin", 0);
     }
     else
     {
        return Utils.readVideoBankFromFile("chr5-1(b).bin", 0);
     }
  }
}