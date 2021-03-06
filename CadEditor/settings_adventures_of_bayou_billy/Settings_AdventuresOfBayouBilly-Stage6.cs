using CadEditor;
using System;
//css_include settings_adventures_of_bayou_billy/BayouBillyUtils.cs;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x851d, 15 , 8*6);   }
  public int getScreenWidth()          { return 8; }
  public int getScreenHeight()         { return 6; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 1   , 0x1000);  }
  public OffsetRec getPalOffset  ()     { return new OffsetRec(0x0 , 1   , 16); }
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return BayouBillyUtils.fakeVideoAddr(); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return BayouBillyUtils.getVideoChunk(new[] {"chr6.bin"}); }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x9953, 1  , 0x1000);  }
  public int getBlocksCount()           { return 161; }
  public int getBigBlocksCount()        { return 161; }
  public int getPalBytesAddr()          { return 0xa363; }
  public GetBlocksFunc        getBlocksFunc() { return Utils.getBlocksFromTiles16Pal1;}
  public SetBlocksFunc        setBlocksFunc() { return Utils.setBlocksFromTiles16Pal1;}
  
  public GetPalFunc           getPalFunc()           { return BayouBillyUtils.readPalFromBin(new[] {"pal6.bin"}); }
  public SetPalFunc           setPalFunc()           { return null;}
}