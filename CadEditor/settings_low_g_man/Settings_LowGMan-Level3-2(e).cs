using CadEditor;
using System;
using PluginMapEditor;
//css_include settings_low_g_man/LowGManUtils.cs;

public class Data 
{  
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x921c, 1 , 16*5);   }
  public int getScreenWidth()          { return 16; }
  public int getScreenHeight()         { return 5; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return LowGManUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return LowGManUtils.getVideoChunk("chr3-2.bin");   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x926c, 1  , 0x1000);  }
  public int getBlocksCount()           { return 160; }
  public int getBigBlocksCount()        { return 160; }
  public int getPalBytesAddr()          { return 0x9488; }
  
  public GetBlocksFunc        getBlocksFunc() { return LowGManUtils.getBlocks;}
  public SetBlocksFunc        setBlocksFunc() { return LowGManUtils.setBlocks;}
  public GetPalFunc           getPalFunc()           { return LowGManUtils.readPalFromBin("pal3-2.bin"); }
  public SetPalFunc           setPalFunc()           { return null;}
}