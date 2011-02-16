package ui{

import flash.display.DisplayObjectContainer;
import flash.events.Event;
import org.aswing.*;
import org.aswing.border.*;
import org.aswing.geom.*;
import org.aswing.colorchooser.*;
import org.aswing.ext.*;

/**
 * ErrorPanel
 */
public class ErrorPanel extends JPanel{
	
	//members define
	private var message:JLabel;
	private var btnOkay:JButton;
	
	/**
	 * ErrorPanel Constructor
	 */
	public function ErrorPanel(_parent:DisplayObjectContainer, name:String, errorMessage:String){
		//component creation
		setSize(new IntDimension(640, 480));
		setOpaque(true);
		
		message = new JLabel();
		message.setFont(new ASFont("Tahoma", 14, true, false, false, false));
		message.setLocation(new IntPoint(5, 5));
		message.setSize(new IntDimension(444, 21));
		message.setText(name + ": " + errorMessage);
		message.setForeground(new ASColor(0xee0000));
		
		btnOkay = new JButton();
		btnOkay.setLocation(new IntPoint(200, 200));
		btnOkay.setSize(new IntDimension(250, 100));
		btnOkay.setText("Okay");
		btnOkay.addActionListener(buttonPressed);
		
		//component layoution
		append(message);
		append(btnOkay);
		
		_parent.addChild(this);
		
	}
	
	//_________getters_________
	
	private function buttonPressed(e:Event):void
	{
		parent.removeChild(this);
	}
	
	
}
}
