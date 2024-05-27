// GameSaveData.cs
using System.Collections.Generic;

namespace CLCProject.Models
{
    public class GameSaveData
    {
        public string UserId { get; set; }
        public List<CellModel> Cells { get; set; }
        // Add other properties as needed
    }
}
