using CadEditor;
using System.Collections.Generic;
public class Data
{ 
  public OffsetRec getScreensOffset()     { return new OffsetRec(0x679A,10, 64);   } 
  public int getScreenWidth()             { return 8; }
  public int getScreenHeight()            { return 8; }
  public string getBlocksFilename()       { return "banana_prince_3c.png"; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return false; }
  public bool isEnemyEditorEnabled()    { return false; }
}