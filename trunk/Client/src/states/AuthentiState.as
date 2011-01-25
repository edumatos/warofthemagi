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
		private var passwrd:Input;
		private var btnConnect:FlxButton;
		[Embed(source = '../images/cursor.png')] private var imgCursor:Class;
		
		public function AuthentiState() 
		{
		}
		
		override public function create():void 
		{
			FlxG.canPause = false;
			add(new FlxText(320 - 62 - 55, 143, 100, "Username:"));
			usrname = new Input("");
			usrname.width = 125;
			usrname.height = 20;
			usrname.x = 320 - 62;
			usrname.y = 140;
			usrname.backgroundColor = 0x00000000;
			usrname.textColor = 0xffffffff;
			usrname.borderColor = 0xffffffff;
			addChild(usrname);
			add(new FlxText(320 - 62 - 55, 168, 100, "Password:"));
			passwrd = new Input("");
			passwrd.displayAsPassword = true;
			passwrd.width = 125;
			passwrd.height = 20;
			passwrd.x = 320 - 62;
			passwrd.y = 165;
			passwrd.backgroundColor = 0x00000000;
			passwrd.textColor = 0xffffffff;
			passwrd.borderColor = 0xffffffff;
			addChild(passwrd);
			
			
			btnConnect = new FlxButton(320, 300, connectClicked);
			btnConnect.loadText(new FlxText(25, 3, 50, "CONNECT"));
			add(btnConnect);
			
			FlxG.mouse.show(imgCursor);

			
		}
		
		override public function update():void 
		{
			super.update();
		}
		
		public function onFade():void
		{
			FlxG.state = new MenuState;
		}
		
		public function connectClicked():void
		{
			removeChild(usrname);
			removeChild(passwrd);
			FlxG.fade.start(0x000000, 1, onFade);
		}
		
	}

}