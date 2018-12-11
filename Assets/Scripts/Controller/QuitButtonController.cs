using UnityEngine;

namespace Controller
{
	public class QuitButtonController : MonoBehaviour
	{

		[SerializeField] private GameController _gameController;
	
	
		private void OnMouseDown()
		{
			_gameController.EndGame();
		}
	}
}
