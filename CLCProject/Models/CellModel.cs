namespace CLCProject.Models
{
    public class CellModel
    {
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsRevealed { get; set; }
        public int NeighboringMines { get; set; }

        public CellModel()
        {
            IsMine = false;
            IsFlagged = false;
            IsRevealed = false;
            NeighboringMines = 0;
        }
    }
}
