/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  
  public World () {
    Space entry    = new Space("Landbrugsskolen");
// hovedrum mose:
    Space mose = new Space("Mosen");
// underrum mose:
    Space mosekant = new Space("Mosekant");
    Space tørvemose = new Space ("Tørvemosen");
    Space udtørretEng = new Space ("Udtørret eng");

// hovedrum 2 (mark)
    Space mark     = new Space("Marken");
// underrum

//hovedrum 3 (vandløb)
    Space vandløb      = new Space("Vandløbet");
    
    entry.AddEdge("north", mose);
    entry.AddEdge("south", mark);
    entry.AddEdge("east", vandløb);
    mose.AddEdge("mosekant", mosekant);
    mosekant.AddEdge("tørvemose", tørvemose);
    udtørretEng.AddEdge("engen", udtørretEng);
    
    
    this.entry = entry;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

