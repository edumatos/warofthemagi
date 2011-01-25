package states 
{
	import org.flixel.*;
	import states.MenuState;
	import ui.Input;
	
	/**
	 * ...
	 * @author ...
	 */
	public class AuthentiState extends FlxState
	{
		private var usrname:Input;
		private var okayButton:FlxButton;
		private var btnText:FlxText;
		[Embed(source = '../images/cursor.png')] private var imgCursor:Class;
		
		public function AuthentiState() 
		{
			btnText = new FlxText(320, 300, 50, "Okay");
			okayButton = new FlxButton(320, 300, okayclicked);
			usrname = new Input("Username");
			usrname.width = 125;
			usrname.height = 20;
			usrname.x = 320 - 62;
			usrname.y = 280;
		}
		
		override public function create():void 
		{
			FlxG.mouse.show(imgCursor);
			okayButton.loadText(btnText);
			add(okayButton);
			
			addChild(usrname);
			//addChild(okayButton);
		}
		
		override public function update():void 
		{
			super.update();
		}
		
		public function onFade():void
		{
			FlxG.state = new MenuState;
		}
		
		public function okayclicked():void
		{
			removeChild(usrname);
			FlxG.fade.start(0x000000, 1, onFade);
		}
		
	}

}