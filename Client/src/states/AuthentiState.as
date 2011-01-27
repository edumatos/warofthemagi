package states 
{
	import org.flixel.*;
	import playerio.*;
	import states.MenuState;
	import ui.Input;
	import game.GameInfo;
	
	/**
	 * ...
	 * @author ...
	 */
	public class AuthentiState extends FlxState
	{
		private var usrname:Input;
		private var passwrd:Input;
		private var btnConnect:FlxButton;
		private var btnRegister:FlxButton;
		private var errorText:FlxText;
		[Embed(source = '../images/cursor2.png')] private var imgCursor:Class;
		
		public function AuthentiState() 
		{
		}
		
		override public function create():void 
		{
			var text:FlxText = new FlxText( 0, (FlxG.height / 2) - 100, FlxG.width, "War of the Magi" );
			text.setFormat( null, 32, 0xff0000ee, "center" );
			add(text);
			FlxG.canPause = false;
			add(new FlxText(320 - 62 - 55, text.y + 43, 100, "Username:"));
			usrname = new Input("");
			usrname.width = 125;
			usrname.height = 20;
			usrname.x = 320 - 62;
			usrname.y = text.y + 40;
			usrname.backgroundColor = 0x00000000;
			usrname.textColor = 0xffffffff;
			usrname.borderColor = 0xffffffff;
			addChild(usrname);
			add(new FlxText(320 - 62 - 55, text.y  + 68, 100, "Password:"));
			passwrd = new Input("");
			passwrd.displayAsPassword = true;
			passwrd.width = 125;
			passwrd.height = 20;
			passwrd.x = 320 - 62;
			passwrd.y = text.y + 65;
			passwrd.backgroundColor = 0x00000000;
			passwrd.textColor = 0xffffffff;
			passwrd.borderColor = 0xffffffff;
			addChild(passwrd);
			errorText = new FlxText(0, text.y - 20, FlxG.width);
			errorText.setFormat(null, 10, 0xffff0000, "center");
			add(errorText);
			
			btnConnect = new FlxButton(320, text.y + 90, connectClicked);
			btnConnect.loadText(new FlxText(25, 3, 50, "CONNECT"));
			add(btnConnect);
			btnRegister = new FlxButton(200, text.y + 90, registerClicked);
			btnRegister.loadText(new FlxText(25, 3, 50, "REGISTER"));
			add(btnRegister);
			
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
		
		private function connectClicked():void
		{
			PlayerIO.quickConnect.simpleConnect(FlxG.stage, "war-of-the-magi-c02pduuwjkw1333jpfm6wq", 
				usrname.text, passwrd.text, connectSuccess, simpleUsersFailure);
		}
		
		private function registerClicked():void
		{
			PlayerIO.quickConnect.simpleRegister(FlxG.stage, "war-of-the-magi-c02pduuwjkw1333jpfm6wq",
				usrname.text, passwrd.text, null, "", "", null, connectSuccess, simpleUsersFailure);
		}
		
		private function connectSuccess(client:Client):void
		{
			GameInfo.client = client;
			GameInfo.username = usrname.text;
			GameInfo.password = passwrd.text;
			FlxG.fade.start(0x000000, 1, onFade);
		}
		
		private function simpleUsersFailure(error:PlayerIOError):void
		{
			usrname.text = "";
			usrname.width = 125;
			passwrd.text = "";
			passwrd.width = 125;
			errorText.text = error.message;
		}
		
	}

}