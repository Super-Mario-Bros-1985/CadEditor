using CadEditor;
using System.Collections.Generic;
//css_include settings_adventure_in_the_magic_kingdoom/AitMKUtils.cs;

public class Data
{ 
  public OffsetRec getScreensOffset()     { return new OffsetRec(0x9E70, 9, 8*9);   }
  public int getScreenWidth()             { return 8; }
  public int getScreenHeight()            { return 8; }
  
  public bool isBigBlockEditorEnabled() { return true; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 2   , 0x1000);  }
  public OffsetRec getPalOffset  ()     { return new OffsetRec(0x0 , 1   , 16); }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return AitMKUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return AitMKUtils.getVideoChunk(new[] {"chr0.bin", "chr0-2.bin"}); }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public OffsetRec getBigBlocksOffset() { return new OffsetRec(0x4D10, 1  , 0x4000); }
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x5510, 1  , 0x1000);  }
  public int getBlocksCount()           { return 256; }
  public int getBigBlocksCount()        { return 512; }
  
  public GetBigTileNoFromScreenFunc getBigTileNoFromScreenFunc() { return AitMKUtils.getBigTileNoFromScreen; }
  public SetBigTileToScreenFunc     setBigTileToScreenFunc()     { return AitMKUtils.setBigTileToScreen; }
  
  public GetBlocksFunc        getBlocksFunc() { return AitMKUtils.getBlocks;}
  public SetBlocksFunc        setBlocksFunc() { return AitMKUtils.setBlocks;}
  public GetBigBlocksFunc     getBigBlocksFunc()     { return Utils.getBigBlocksCapcomDefault;}
  public SetBigBlocksFunc     setBigBlocksFunc()     { return Utils.setBigBlocksCapcomDefault;}
  public GetPalFunc           getPalFunc()           { return AitMKUtils.readPalFromBin(new[] {"pal0.bin"}); }
  public SetPalFunc           setPalFunc()           { return null;}
}