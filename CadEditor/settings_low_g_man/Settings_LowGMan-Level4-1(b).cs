using CadEditor;
using System;
using PluginMapEditor;
//css_include settings_low_g_man/LowGManUtils.cs;

public class Data 
{  
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xa7af, 1 , 16*15);   }
  public int getScreenWidth()          { return 16; }
  public int getScreenHeight()         { return 15; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return LowGManUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return LowGManUtils.getVideoChunk("chr4-1.bin");   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xa89f, 1  , 0x1000);  }
  public int getBlocksCount()           { return 256; }
  public int getBigBlocksCount()        { return 256; }
  public int getPalBytesAddr()          { return 0xac43; }
  
  public GetBlocksFunc        getBlocksFunc() { return LowGManUtils.getBlocks;}
  public SetBlocksFunc        setBlocksFunc() { return LowGManUtils.setBlocks;}
  public GetPalFunc           getPalFunc()           { return LowGManUtils.readPalFromBin("pal4-1.bin"); }
  public SetPalFunc           setPalFunc()           { return null;}
}