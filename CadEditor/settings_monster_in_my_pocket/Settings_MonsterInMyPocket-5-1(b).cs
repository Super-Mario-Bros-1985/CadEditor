using CadEditor;
using System.Collections.Generic;
public class Data
{ 
  public OffsetRec getScreensOffset()     { return new OffsetRec(0x461c, 9 , 48);   }
  public int getScreenWidth()             { return 8; }
  public int getScreenHeight()            { return 6; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public OffsetRec getVideoOffset()   { return new OffsetRec(0x37010, 1, 0x1000); }
  public OffsetRec getPalOffset()     { return new OffsetRec(0x1d587, 1, 16   ); }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc()         { return Utils.getChrAddress; }
  public GetVideoChunkFunc    getVideoChunkFunc()            { return Utils.getVideoChunk; }
  public SetVideoChunkFunc    setVideoChunkFunc()            { return Utils.setVideoChunk; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x4b6c, 1, 0x1000);  }
  public int getBlocksCount()           { return 256; }
  public int getBigBlocksCount()        { return 256; }
  public int getPalBytesAddr()          { return 0x515c; }
  public GetBlocksFunc        getBlocksFunc() { return Utils.getBlocksFromTiles16Pal1;}
  public SetBlocksFunc        setBlocksFunc() { return Utils.setBlocksFromTiles16Pal1;}
  
  public GetPalFunc           getPalFunc() { return Utils.getPalleteLinear;}
  public SetPalFunc           setPalFunc() { return Utils.setPalleteLinear;}
  
  //----------------------------------------------------------------------------
}