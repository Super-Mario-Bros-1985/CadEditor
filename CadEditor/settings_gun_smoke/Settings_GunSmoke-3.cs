using CadEditor;
using System;
using System.Collections.Generic;
//css_include settings_gun_smoke/GunSmokeUtils.cs;

public class Data
{ 
  public OffsetRec getScreensOffset()     { return new OffsetRec(0x8410, 1, 8*159);  }
  public OffsetRec getBigBlocksOffset()   { return new OffsetRec(0x8010 , 1, 0x4000); }
  public OffsetRec getVideoOffset()       { return new OffsetRec(0x0 , 2   , 0x1000);  }
  public OffsetRec getPalOffset  ()       { return new OffsetRec(0x0 , 1   , 16); }
  public int getScreenWidth()    { return 8; }
  public int getScreenHeight()   { return 159; }
  public int getBigBlocksCount() { return 256; }
  public int getBlocksCount()    { return 64; }
  
  public GetBigTileNoFromScreenFunc getBigTileNoFromScreenFunc() { return GunSmokeUtils.getBigTileNoFromScreen; }
  public SetBigTileToScreenFunc     setBigTileToScreenFunc()     { return GunSmokeUtils.setBigTileToScreen; }
  
  public bool isBigBlockEditorEnabled() { return true; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc()          { return GunSmokeUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()             { return GunSmokeUtils.getVideoChunk(new[] {"chr3.bin", "chr3-2.bin"}); }
  public SetVideoChunkFunc    setVideoChunkFunc()             { return null; }
  public GetBlocksFunc        getBlocksFunc()                 { return GunSmokeUtils.getBlocks;}
  public SetBlocksFunc        setBlocksFunc()                 { return null; }
  public GetBigBlocksFunc     getBigBlocksFunc()              { return GunSmokeUtils.getBigBlocks;}
  public SetBigBlocksFunc     setBigBlocksFunc()              { return GunSmokeUtils.setBigBlocks;}
  public GetPalFunc           getPalFunc()                    { return GunSmokeUtils.readPalFromBin(new[] {"pal3.bin"}); }
  public SetPalFunc           setPalFunc()                    { return null;}
}