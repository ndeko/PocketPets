using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SymbokuGameMaster : MonoBehaviour {

	#region/**************** Properties ********************/
	GameObject SelectedTile;
	GameObject SelectedIcon;
	int[,] ValueGrid;
	int[,] AnswerKey = {{4,1,3,2},{3,2,4,1},{1,3,2,4},{2,4,1,3}};
	public GameObject[] BoardTiles;
	public GameObject[] Icons;
	int TilesToSpawn;
	int RoundsDone;
	//take answer
	//swap numbers
	//that is this answer
	//spawn in the pattern

	#endregion
	// Use this for initialization
	void Start () 
	{
		TilesToSpawn = 8;
		ValueGrid = new int[4,4];
		SelectedIcon = null;
		SelectedTile = null;
		SpawnInBoard();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void SpawnInBoard()
	{
		GetNewBoard();
		ShuffleSpawn(BoardTiles);

	}
	//Works but needs a fail backup IN CASE a high number is needed
	void ShuffleSpawn(GameObject[] BoardTiles) 
	{
		int[,] ThisAnswer = SwapNumbers(AnswerKey, 2);
		//Random rng = new Random(); 
		int n = BoardTiles.Length - 1;
		int SpawnCount = TilesToSpawn - RoundsDone;
		if(SpawnCount < 5)
		{
			SpawnCount = 5;
		}
		//int failCount = 0;
		while (SpawnCount > 0) 
		{  
			//Get next tile
			int ran = Random.Range(0, n);
			GameObject ThisTile = BoardTiles[ran];
			if(ThisTile.GetComponent<BoardTile>().Changeable == false)
			{
				continue;
			}
			//get its x and y
			int col = ThisTile.GetComponent<BoardTile>().col;
			int row = ThisTile.GetComponent<BoardTile>().row;
			//check the answer for what it should be
			int CorrectValue = ThisAnswer[row - 1,col- 1];
			//get the correct tile
			//spawn in that tile
			ThisTile.GetComponent<SpriteRenderer>().sprite =
				Icons[CorrectValue - 1].GetComponent<SpriteRenderer>().sprite;
			//make that tile unselectable
			ThisTile.GetComponent<BoardTile>().Changeable = false;
			//add that to the answer grid
			ValueGrid[row - 1,col - 1] = CorrectValue;
			SpawnCount--;
		}  
	}
#region /**************** SETTERS ********************/
	public void SetIcon(GameObject Icon)
	{
		if(SelectedTile != null)
		{

			SelectedIcon = Icon;
			//Make the variables because this shit is too long
			int SelectedRow = SelectedTile.GetComponent<BoardTile>().row - 1;
			int SelectedCol = SelectedTile.GetComponent<BoardTile>().col - 1;
			int SelectedVal = SelectedIcon.GetComponent<BoardIcon>().Value;

			if(CheckEntry(SelectedRow, SelectedCol, SelectedVal))
			{
				ValueGrid[SelectedRow, SelectedCol] = SelectedVal;
				SelectedTile.GetComponent<SpriteRenderer>().sprite = SelectedIcon.GetComponent<SpriteRenderer>().sprite;
				//Play sound
				//check if puzzle is complete
				if(CheckIfFinished())
				{
					print("Finished");
					GetNewBoard();
					ShuffleSpawn(BoardTiles);
				}
				//wipe selected objects
				SelectedTile = null;
				SelectedIcon = null;
			}
			//else
			{
				//player made and invalid placements
			}
		}
	}

	public void SetTile(GameObject Tile)
	{
		SelectedTile = Tile;
	}
#endregion
#region /**************** CHECKS ********************/
	bool CheckEntry(int Row, int Col, int Value)
	{
		if(CheckColumn(Col, Value))
		{
			if(CheckRow(Row, Value))
			{
				if(CheckQuad(Row, Col, Value))
				{
					return true;
				}
			}

		}
		return false;
	}
	bool CheckColumn(int col, int value)
	{
		for(int Brow = 0; Brow < 4; Brow++)
		{
			if(ValueGrid[Brow,col] == value)
			{
				print("FAIL Col");
				return false;
			}
		}
		print ("PASS COL");
		return true;
	}
	
	bool CheckRow(int row, int value)
	{
		for (int Bcol = 0; Bcol < 4; Bcol++)
		{
			if(ValueGrid[row,Bcol] == value)
			{
				print("FAIL Row");
				return false;
			}
		}
		print ("PASS ROW");
		return true;
	}
	
	bool CheckQuad(int row, int col, int value)
	{
		int rowToStart;
		int colToStart;
		
		if(row < 2)
		{
			rowToStart = 0;
		}
		else
		{
			rowToStart = 2;
		}
		
		if(col < 2)
		{
			colToStart = 0;
		}
		else
		{
			colToStart = 2;
		}
		for (int checkRow = rowToStart; checkRow <= rowToStart + 1; checkRow++)
		{
			for(int checkCol = colToStart; checkCol <= colToStart + 1; checkCol++)
			{
				if(checkRow == row && checkCol == col)
				{
					continue;
				}
				if(ValueGrid[checkRow,checkCol] == value)
				{
					print("FAIL QUAD");
					return false;
				}
			}
		}
		print ("PASS QUAD");
		return true;
	}
	bool CheckIfFinished()
	{
		for(int row = 0; row < 4; row++)
		{
			for(int col = 0; col < 4; col++)
			{
				if(ValueGrid[row,col] == 0)
				{
					return false;
				}
			}
		}
		return true;
	}
#endregion
#region /**************** Board Setup ********************/
	void GetNewBoard()
	{
		for(int i = 0; i < 16; i++)
		{
			BoardTiles[i].GetComponent<SpriteRenderer>().sprite = null;
			BoardTiles[i].GetComponent<BoardTile>().Changeable = true;
		}
		for (int row = 0; row < 4; row++)
		{
			for(int col = 0; col < 4; col++)
			{
				ValueGrid[row,col] = 0;
			}
		}
		RoundsDone++;
	}
	public int[,] SwapNumbers(int[,] grid, int passes)
	{
		for(int i = 0; i < passes; i++)
		{
			//Pick 2 random numbers to swap places
			int num1 = Random.Range(1,4);
			int num2 = Random.Range(1,4);
			//print("1: " + num1 + " 2: " + num2);
			while(num1==num2)
			{
				num2 = Random.Range(1,4);
			}
			for (int row = 0; row < 4; row++)
			{
				for(int col = 0; col < 4; col++)
				{
					if(grid[row,col] == num1)
					{
						grid[row,col] = num2;
					}
					else if(grid[row,col] == num2)
					{
						grid[row,col] = num1;
					}
				}
			}
		}
		return grid;
	}
	#endregion
}

