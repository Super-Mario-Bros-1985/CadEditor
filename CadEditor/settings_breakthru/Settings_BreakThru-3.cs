using CadEditor;
using System;
//css_include shared_settings/BlockUtils.cs;
//css_include shared_settings/SharedUtils.cs;

public class Data 
{ 
  public OffsetRec getScreensOffset() { return new OffsetRec(0xc761, 25, 16*15); }
  public int getScreenWidth()         { return 16; }
  public int getScreenHeight()        { return 15; }
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return SharedUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return SharedUtils.getVideoChunk("chr3.bin");    }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xc110, 1  , 0x1000);  }
  public int getBlocksCount()           { return 256; }
  public int getBigBlocksCount()        { return 256; }
  public int getPalBytesAddr()          { return 0xc710; }
  
  public GetBlocksFunc        getBlocksFunc() { return BlockUtils.getBlocksAlignedWithSeparatePal;}
  public SetBlocksFunc        setBlocksFunc() { return BlockUtils.setBlocksAlignedWithSeparatePal;}
  public GetPalFunc           getPalFunc()           { return SharedUtils.readPalFromBin(new[] {"pal3.bin"}); }
  public SetPalFunc           setPalFunc()           { return null;}
}