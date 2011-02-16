package  game
{
	import playerio.*;
	
	/**
	 * ...
	 * @author ...
	 */
	public class GameInfo 
	{
		
		/**
		 * All players in this game.
		 */
		public static var Wizards:Array = new Array;
		
		public static var username:String;
		
		public static var password:String;
		
		public static var client:Client;
		
		public static var connection:Connection;
		
		//TODO: add anything else needed for game operations
		
		
		public function GameInfo() 
		{
		}
		
	}

}