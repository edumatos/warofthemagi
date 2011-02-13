package states 
{
	import flash.events.Event;
	import flash.ui.Mouse;
	import org.flixel.*;
	import org.flixel.data.FlxPanel;
	import playerio.*;
	import states.MenuState;
	import ui.ErrorPanel;
	import ui.LoginPanel;
	import game.GameInfo;
	
	/**
	 * ...
	 * @author ...
	 */
	public class AuthentiState extends FlxState
	{
		
		private var loginPanel:LoginPanel;
		private var errorBox:ErrorPanel;
		
		[Embed(source = '../images/cursor2.png')] private var imgCursor:Class;
		
		public function AuthentiState() 
		{
		}
		
		override public function create():void 
		{
			FlxG.canPause = false;
			
			loginPanel = new LoginPanel();
			loginPanel.width = 640;
			loginPanel.height = 480;
			loginPanel.getBtnRegister().addActionListener(registerClicked);
			loginPanel.getBtnConnect().addActionListener(connectClicked);
			addChild(loginPanel);
			
			var text:FlxText = new FlxText( 0, (FlxG.height / 2) - 120, FlxG.width, "War of the Magi" );
			text.setFormat( null, 32, 0xff0000ee, "center" );
			add(text);
			
			Mouse.show();
			//FlxG.mouse.show(imgCursor);
			
		}
		
		override public function update():void 
		{
			if (FlxG.keys.pressed("ENTER"))
			{
				connectClicked(new Event(""));
			}
			super.update();
		}
		
		public function onFade():void
		{
			FlxG.state = new MenuState;
		}
		
		private function connectClicked(e:Event):void
		{
			PlayerIO.quickConnect.simpleConnect(FlxG.stage, "war-of-the-magi-c02pduuwjkw1333jpfm6wq", 
				loginPanel.getUsernameField().getText(), loginPanel.getPasswordField().getText(), connectSuccess, simpleUsersFailure);
		}
		
		private function registerClicked(e:Event):void
		{
			PlayerIO.quickConnect.simpleRegister(FlxG.stage, "war-of-the-magi-c02pduuwjkw1333jpfm6wq",
				loginPanel.getUsernameField().getText(), loginPanel.getPasswordField().getText(), null, "", "", null, connectSuccess, simpleUsersFailure);
		}
		
		private function connectSuccess(client:Client):void
		{
			GameInfo.client = client;
			GameInfo.username = loginPanel.getUsernameField().getText();
			GameInfo.password = loginPanel.getPasswordField().getText();
			FlxG.fade.start(0x000000, 1, onFade);
		}
		
		private function simpleUsersFailure(error:PlayerIOError):void
		{
			loginPanel.getUsernameField().setText("");
			loginPanel.getPasswordField().setText("");
			errorBox = new ErrorPanel(this, error.name, error.message);
		}
		
	}

}