package ui {
	
	import org.aswing.*;
	import org.aswing.geom.IntDimension;
	
	public class ErrorBox extends JFrame
	{
		private var btnPanel:JPanel;
		private var pnlMessage:JPanel;
		private var btnOkay:JButton;
		private var messageDisplay:JLabel;
		
		public function ErrorBox(title:String , message:String)
		{
			super(AsWingManager.getRoot(false), title, true);
			btnPanel = new JPanel();
			btnOkay = new JButton("Okay");
			btnOkay.setPreferredSize(new IntDimension(75, 22));
			btnOkay.addActionListener(buttonPressed);
			btnPanel.setLayout(new FlowLayout (FlowLayout.RIGHT, 20, 8));
			btnPanel.append(btnOkay);
			pnlMessage = new JPanel;
			messageDisplay = new JLabel(message);
			pnlMessage.setLayout(new FlowLayout (FlowLayout.CENTER));
			pnlMessage.append(messageDisplay);
			getContentPane().append(pnlMessage, BorderLayout.CENTER);
			getContentPane().append(btnPanel, BorderLayout.SOUTH);
		}
		
		private function buttonPressed():void
		{
			tryToClose();
		}
	}
}