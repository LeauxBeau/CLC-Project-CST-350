using CLCProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        CalculateNeighboringMines();

        return View("Minesweeper", cells);
    }

    [HttpPost]
    public IActionResult HandleCellClick(int cellIndex)
    {
        var clickedCell = cells[cellIndex];

        if (clickedCell.IsMine)
        {
            return Json(new { gameOver = true });
        }
        else
        {
            RevealEmptyCells(cellIndex);

            if (CheckGameWon())
            {
                return Json(new { gameOver = true });
            }
            else
            {
                return Json(new { gameOver = false, cells = cells });
            }
        }
    }

    [HttpGet]
    public IActionResult ResetBoard()
    {
        InitializeGrid();
        PlaceMines();
        CalculateNeighboringMines();

        var dateTimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        return Json(new { cells = cells, dateTime = dateTimeNow });
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

    private void CalculateNeighboringMines()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            if (!cells[i].IsMine)
            {
                int count = 0;
                foreach (var neighborIndex in GetNeighborIndices(i))
                {
                    if (neighborIndex >= 0 && neighborIndex < cells.Count && cells[neighborIndex].IsMine)
                    {
                        count++;
                    }
                }
                cells[i].NeighboringMines = count;
            }
        }
    }

    private IEnumerable<int> GetNeighborIndices(int index)
    {
        int row = index / GRID_SIZE;
        int col = index % GRID_SIZE;

        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (i >= 0 && i < GRID_SIZE && j >= 0 && j < GRID_SIZE && (i != row || j != col))
                {
                    yield return i * GRID_SIZE + j;
                }
            }
        }
    }

    private void RevealEmptyCells(int cellIndex)
    {
        var queue = new Queue<int>();
        queue.Enqueue(cellIndex);

        while (queue.Count > 0)
        {
            var currentIndex = queue.Dequeue();
            cells[currentIndex].IsRevealed = true;

            if (cells[currentIndex].NeighboringMines == 0)
            {
                foreach (var neighborIndex in GetNeighborIndices(currentIndex))
                {
                    if (!cells[neighborIndex].IsRevealed && !cells[neighborIndex].IsMine)
                    {
                        queue.Enqueue(neighborIndex);
                    }
                }
            }
        }
    }

    private bool CheckGameWon()
    {
        foreach (var cell in cells)
        {
            if (!cell.IsRevealed && !cell.IsMine)
            {
                return false;
            }
        }
        return true;
    }
}
