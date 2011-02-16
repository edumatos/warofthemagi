package  states
{
	import org.flixel.FlxState;
	import org.flixel.FlxText;
	import org.flixel.FlxG;
	import states.MenuState;

	/**
	 * ...
	 * @author GDSkeptic
	 */
	public class EndState extends FlxState
	{
		
		public function EndState()
		{
		}

		override public function create():void
		{
			var txt:FlxText = new FlxText(0, (FlxG.width / 2) - 80, FlxG.width, "You won the game!");
			txt.setFormat(null, 16, 0xFFFFFF, "center");
			add(txt);

			txt = new FlxText(0, FlxG.height - 24, FlxG.width, "PRESS X TO END");
			txt.setFormat(null, 8, 0xFFFFFF, "center");
			add(txt);
		}
		
		override public function update():void
		{
			if (FlxG.keys.pressed("ENTER"))
			{
				FlxG.flash.start(0xFFFFFF, 0.75);
				FlxG.fade.start(0x000000, 1, onFade);
			}
		}
		
		public function onFade():void
		{
			FlxG.state = new MenuState;
		}
	}

}
