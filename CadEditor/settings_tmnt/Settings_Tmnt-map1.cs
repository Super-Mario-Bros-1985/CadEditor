using CadEditor;
using System;
using System.Drawing;

public class Data 
{ 
  public OffsetRec getScreensOffset() { return new OffsetRec(0x4079, 4, 64); }
  public int getScreenWidth()         { return 8; }
  public int getScreenHeight()        { return 8; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public OffsetRec getVideoOffset()   { return new OffsetRec(0x32010, 1, 0x1000); }
  public OffsetRec getPalOffset()     { return new OffsetRec(0x1f7da, 16, 16   ); }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc()         { return Utils.getChrAddress; }
  public GetVideoChunkFunc    getVideoChunkFunc()            { return Utils.getVideoChunk; }
  public SetVideoChunkFunc    setVideoChunkFunc()            { return Utils.setVideoChunk; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x10011 , 1  , 0x1000);  }
  public int getBlocksCount()           { return 212; }
  public int getBigBlocksCount()        { return 212; }
  public int getPalBytesAddr()          { return 0x10a01; }
  public GetBlocksFunc        getBlocksFunc() { return Utils.getBlocksFromTiles16Pal1;}
  public SetBlocksFunc        setBlocksFunc() { return Utils.setBlocksFromTiles16Pal1;}
  public GetPalFunc           getPalFunc()           { return getPallete;}
  public SetPalFunc           setPalFunc()           { return null;}
  
  public byte[] getPallete(int palId)
  {
    var pallete = new byte[] { 
      0x0f, 0x00, 0x10, 0x20, 0x0f, 0x01, 0x11, 0x21,
      0x0f, 0x06, 0x26, 0x37, 0x0f, 0x00, 0x00, 0x00
    }; 
    return pallete;
  }
}