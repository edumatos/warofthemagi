package states
{
	import org.flixel.*;
	import states.PlayState;

	/**
	 * ...
	 * @author GDSkeptic
	 */
	public class MenuState extends FlxState
	{
		public function MenuState():void
		{
		}

		override public function create():void
		{
			var text:FlxText = new FlxText( 0, (FlxG.height / 2) - 80, FlxG.width, "Game Title" );
			
			text.setFormat( null, 32, 0xeeeeeeee, "center" );
			this.add(text);
			
			text = new FlxText( 0, FlxG.height - 24, FlxG.width, "Press ENTER to start" );
			text.setFormat( null, 16, 0xcccccccc, "center" );
			this.add(text);
		}
		
		override public function update():void
		{
			if ( FlxG.keys.pressed("ENTER") )
			{
				FlxG.fade.start(0xee000000, .5, onFade);
			}
			super.update();
		}
		
		private function onFade():void
		{
			FlxG.state = new PlayState();
		}
	}
	
}
