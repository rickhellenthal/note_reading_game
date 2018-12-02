namespace Model
{
	public static class CrossSceneInfo
	{

		// EndGame information
		public static int ScoreAchieved = 0;
		public static int NumberOfAssignmentsWrong = 0;
		public static int NumberOfAssignmentsCorrect = 0;
	
		// Settings
		public static int ClefSetting = 0; // 0 = Right hand only, 1 = Left hand only, 2 = Both hands
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
