using System.ComponentModel.DataAnnotations.Schema;

namespace CLCProject.Models
{
    [Table("GameBoard")]
    public class GameBoardModel
    {
        public int RowId { get; set; }
        public int ColumnId { get; set; }
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
    }
}
