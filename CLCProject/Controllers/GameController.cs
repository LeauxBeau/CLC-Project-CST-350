using CLCProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CLCProject.Controllers
{
    public class MinesweeperController : Controller
    {
        static List<CellModel> cells = new List<CellModel>();
        Random random = new Random();
        const int GRID_SIZE = 10;
        const int MINE_COUNT = 10;

        public ActionResult Index()
        {
            InitializeGrid();
            PlaceMines();

            return View("Minesweeper", cells);
        }

        public IActionResult HandleCellClick(int cellIndex)
        {
            // Implement logic to handle cell click
            // Check if the cell is a mine, reveal it, reveal neighboring cells, handle game over, etc.

            return View("Minesweeper", cells);
        }

        private void InitializeGrid()
        {
            cells = new List<CellModel>();

            for (int i = 0; i < GRID_SIZE * GRID_SIZE; i++)
            {
                cells.Add(new CellModel());
            }
        }

        private void PlaceMines()
        {
            HashSet<int> mineIndices = new HashSet<int>();

            while (mineIndices.Count < MINE_COUNT)
            {
                int randomIndex = random.Next(GRID_SIZE * GRID_SIZE);
                mineIndices.Add(randomIndex);
            }

            foreach (int index in mineIndices)
            {
                cells[index].IsMine = true;
            }
        }
    }
}
