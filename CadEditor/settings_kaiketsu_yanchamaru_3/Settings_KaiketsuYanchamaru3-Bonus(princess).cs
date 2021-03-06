using CadEditor;
using System;
//css_include settings_kaiketsu_yanchamaru_3/KaiketsuUtils.cs;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xbde7, 1 , 11*5);   }
  public int getScreenWidth()          { return 11; }
  public int getScreenHeight()         { return 5; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return false; }
  
  public GetVideoPageAddrFunc getVideoPageAddrFunc() { return getVideoAddress; }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return getVideoChunk;   }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public bool isBuildScreenFromSmallBlocks() { return true; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xe310, 1  , 0x1000);  }
  public int getBlocksCount()           { return 256; }
  public int getBigBlocksCount()        { return 256; }
  public int getPalBytesAddr()          { return 0xe710; }
  
  public GetBlocksFunc        getBlocksFunc() { return KaiketsuUtils.getBlocks;}
  public SetBlocksFunc        setBlocksFunc() { return KaiketsuUtils.setBlocks;}
  public GetPalFunc           getPalFunc()           { return getPallete;}
  public SetPalFunc           setPalFunc()           { return null;}
  //----------------------------------------------------------------------------
  
  public byte[] getPallete(int palId)
  {
      return Utils.readBinFile("pal(bonus0).bin");
  }
  
  public int getVideoAddress(int id)
  {
    return -1;
  }
  
  public byte[] getVideoChunk(int videoPageId)
  {
     return Utils.readVideoBankFromFile("chr(bonus0).bin", videoPageId);
  }
}