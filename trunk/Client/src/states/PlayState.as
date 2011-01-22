package  states
{
	import org.flixel.*;
	import states.EndState;

	/**
	 * ...
	 * @author GDSkeptic
	 */
	public class PlayState extends FlxState
	{
		public function PlayState()
		{
		}

		override public function create():void
		{
			/* initialization code */
			
			var text:FlxText = new FlxText( 0, FlxG.height - 24, FlxG.width, "The game has started, currently in the play state." );
			text.setFormat( null, 16, 0xcccccccc, "center" );
			this.add(text);
			
		}
		
		override public function update():void
		{
			/* your code here */
			if (FlxG.keys.pressed("ENTER"))
			{
				FlxG.flash.start(0xFFFFFF, 0.75);
				FlxG.fade.start(0x000000, 1, onFade);
			}
			
			super.update();
		}

		public function onFade():void
		{
			FlxG.state = new EndState;
		}
	}
	
}