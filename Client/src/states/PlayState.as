package  states
{
	import org.aswing.JTextField;
	import org.aswing.plaf.basic.border.FrameBorder;
	import org.flixel.*;
	import states.EndState;
	import game.GameInfo;

	/**
	 * ...
	 * @author GDSkeptic
	 */
	public class PlayState extends FlxState
	{
		
		private var statusText:FlxText;
		private var chatbox:JTextField;
		
		public function PlayState()
		{
		}

		override public function create():void
		{
			/* initialization code */
			statusText = new FlxText(128, 0, 544, "Waiting for players to connect. Press enter to chat.");
			//statusText = new FlxText(128, 0, 544, "Wave: 0 Time: 00:00 Mana: 0");
			statusText.setFormat( null, 12, 0xcccccccc, "center", 0x7F000000 );
			this.add(text);
			
			chatbox = new JTextField();
			chatbox.setLocationXY(128, 580);
			chatbox.setWidth(544);
			chatbox.setHeight(20);
			chatbox.setForeground(new ASColor(0xffffff, 1));
			chatbox.setBackground(new ASColor(0x333333, 1));
			chatbox.setVisible(false);
			addChild(chatbox);
			
		}
		
		override public function update():void
		{
			/* your code here */
			if (FlxG.keys.pressed("ENTER"))
			{
				// todo: text box message stuff
				if (chatbox.visible)
				{
					//todo: send message
					chatbox.setVisible(false);
					GameInfo.connection.send("WizardText", chatbox.getText());
					chatbox.setText("");
				}
				else
				{
					chatbox.setVisible(true);
					chatbox.requestFocus();
				}
				
				//FlxG.flash.start(0xFFFFFF, 0.75);
				//FlxG.fade.start(0x000000, 1, onFade);
			}
			
			if (FlxG.mouse.justPressed())
			{
				// todo: handle ui stuffs
			}
			
			super.update();
		}

		public function onFade():void
		{
			FlxG.state = new EndState;
		}
	}
	
}