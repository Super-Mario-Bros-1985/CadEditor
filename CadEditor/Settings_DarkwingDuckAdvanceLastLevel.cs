using CadEditor;
using System.Collections.Generic;
//css_include Settings_CapcomBase.cs;
public class Data:CapcomBase
{
  public OffsetRec getPalOffset()       { return new OffsetRec(0x3F1B0, 32  , 16);     }
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x70010, 32  , 0x1000); }
  public OffsetRec getVideoObjOffset()  { return new OffsetRec(0x60010, 32  , 0x1000); }
  public OffsetRec getBigBlocksOffset() { return new OffsetRec(0x276F0 , 1   , 0x4000); }
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x27AF0 , 1   , 0x4000); }
  public OffsetRec getScreensOffset()   { return new OffsetRec(0x20010   , 300 , 0x40);   }
  public IList<LevelRec> getLevelRecs() { return levelRecsDwd; }
  
  public IList<LevelRec> levelRecsDwd = new List<LevelRec>() 
  {
    new LevelRec(0x30410, 128, 17, 4,  0x1C394), 
  };
  //temp hack
  public bool isDwdAdvanceLastLevel() { return true; }
}