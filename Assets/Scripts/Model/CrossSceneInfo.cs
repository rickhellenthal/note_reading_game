namespace Model
{
	public static class CrossSceneInfo
	{

		// EndGame information
		public static int ScoreAchieved = 0;
		public static int NumberOfAssignmentsWrong = 0;
		public static int NumberOfAssignmentsCorrect = 0;
	
		// Settings
		public static bool IncludeSharpNotes = true;
		public static bool IncludeFlatNotes = true;

		public static void Reset()
		{
			ScoreAchieved = 0;
			NumberOfAssignmentsWrong = 0;
			NumberOfAssignmentsCorrect = 0;
		}
	}
}
