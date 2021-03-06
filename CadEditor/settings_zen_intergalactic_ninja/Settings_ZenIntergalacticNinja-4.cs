using CadEditor;
using System;
//css_include settings_zen_intergalactic_ninja/ZenUtils.cs;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(/*0x56b7*/0x5b6a - 64*2, 16 , 8*6); } //0x5b6a - 64*19 + 1
  public int getScreenWidth()          { return 8; }
  public int getScreenHeight()         { return 6; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 2   , 0x1000);  }
  public OffsetRec getPalOffset  ()     { return new OffsetRec(0x0 , 2   , 16); }
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return ZenUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return ZenUtils.getVideoChunk(new[] {"chr5.bin", "chr5-2.bin"}); }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x5CAA, 1  , 0x1000);  }
  public int getBlocksCount()           { return 244; }
  public int getBigBlocksCount()        { return 244; }
  public int getPalBytesAddr()          { return 0x5CAA + 244*16; }
  
  public GetBlocksFunc        getBlocksFunc() { return Utils.getBlocksFromTiles16Pal1;}
  public SetBlocksFunc        setBlocksFunc() { return Utils.setBlocksFromTiles16Pal1;}
  public GetPalFunc           getPalFunc()           { return ZenUtils.readPalFromBin(new[] {"pal5.bin", "pal5-2.bin"}); }
  public SetPalFunc           setPalFunc()           { return null;}
  
  //----------------------------------------------------------------------------
}