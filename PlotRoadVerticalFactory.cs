public static class PlotRoadVerticalFactory
{
	public static Plot GenerateAreas(Plot plot)
	{
		plot.Areas = InstantiateAreas(plot);
		return plot;
	}


	static IList<Area> InstantiateAreas(Plot plot)
	{
		var areas = new List<Area>();


		// define a position to put the vertical road
		var randomVerticalRoadPosition = Random.Range(0, plot.Size.x -1);
		var leftExitPosition = Random.Range(0, plot.Size.y - 1);
		var rightExitPosition = Random.Range(0, plot.Size.y - 1);


		// loop into each possible Area
		for (int i = 0; i < plot.Size.x; i++)
		{
			for (int j = 0; j < plot.Size.y; j++)
			{
			AreaTypeEnum type;
			GameObject prefab = null;


			// add the road area type, the entrance and exit
			if (i == randomVerticalRoadPosition)
			{
				type = AreaTypeEnum.Road;
				if (j == 0 && plot.Exits[(int)ExitEnum.Bottom]) // first on bottom
				{
					var prefab1 = GameAssets.GetRandomPrefab(GameAssets.i.p_exit_bottom);
					areas.Add(new Area() { Position = new Vector2Int(i, j - 1), Type = type, Prefab = prefab1, IsEntrance = true });
				} else if (j == plot.Size.y - 1 && plot.Exits[(int)ExitEnum.Top]) // last on top
				{
					var prefab1 = GameAssets.GetRandomPrefab(GameAssets.i.p_exit_top);
					areas.Add(new Area() { Position = new Vector2Int(i, j + 1), Type = type, Prefab = prefab1, IsExit = true });
				}
			}
			else
			{
			// take a random take different of road
				do
				{
				type = (AreaTypeEnum)Random.Range(0, Enum.GetValues(typeof(AreaTypeEnum)).Length);
				} while (type == AreaTypeEnum.Road);
				}


				// get an random prefab based on the type
				if (type == AreaTypeEnum.Road)
				{
					prefab = GameAssets.GetRandomPrefab(GameAssets.i.p_verticalRoads);
				} else if (type == AreaTypeEnum.GreenArea)
				{
					prefab = GameAssets.GetRandomPrefab(GameAssets.i.p_smallGreenAreas);
				} else if (type == AreaTypeEnum.Building)
				{
					prefab = GameAssets.GetRandomPrefab(GameAssets.i.p_smallBuildings);
				}
				areas.Add(new Area() { Position = new Vector2Int(i, j), Type = type, Prefab = prefab });
			}
		}

		return areas;
		}

	}
}