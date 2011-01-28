package ui{

import org.aswing.*;
import org.aswing.border.*;
import org.aswing.geom.*;
import org.aswing.colorchooser.*;
import org.aswing.ext.*;

/**
 * LoginPanel
 */
public class LoginPanel extends JPanel{
	
	//members define
	private var pnlGroup:JPanel;
	private var pnlUsername:JPanel;
	private var lblUsername:JLabel;
	private var usernameField:JTextField;
	private var pnlPassword:JPanel;
	private var lblPassword:JLabel;
	private var passwordField:JTextField;
	private var pnlButtons:JPanel;
	private var btnRegister:JButton;
	private var btnConnect:JButton;
	
	/**
	 * LoginPanel Constructor
	 */
	public function LoginPanel(){
		//component creation
		setLocation(new IntPoint(0, 0));
		setSize(new IntDimension(640, 480));
		setPreferredSize(new IntDimension(640, 480));
		var layout0:CenterLayout = new CenterLayout();
		setLayout(layout0);
		
		pnlGroup = new JPanel();
		pnlGroup.setLocation(new IntPoint(220, 195));
		pnlGroup.setSize(new IntDimension(200, 90));
		pnlGroup.setPreferredSize(new IntDimension(200, 90));
		var layout1:SoftBoxLayout = new SoftBoxLayout();
		layout1.setAxis(AsWingConstants.VERTICAL);
		layout1.setAlign(AsWingConstants.RIGHT);
		pnlGroup.setLayout(layout1);
		
		pnlUsername = new JPanel();
		pnlUsername.setLocation(new IntPoint(0, 8));
		pnlUsername.setSize(new IntDimension(200, 30));
		var layout2:FlowLayout = new FlowLayout();
		layout2.setAlignment(AsWingConstants.RIGHT);
		pnlUsername.setLayout(layout2);
		
		lblUsername = new JLabel();
		lblUsername.setForeground(new ASColor(0xffffff, 1));
		lblUsername.setLocation(new IntPoint(9, 6));
		lblUsername.setSize(new IntDimension(56, 17));
		lblUsername.setText("Username:");
		
		usernameField = new JTextField();
		usernameField.setForeground(new ASColor(0xffffff, 1));
		usernameField.setBackground(new ASColor(0x333333, 1));
		usernameField.setLocation(new IntPoint(70, 5));
		usernameField.setSize(new IntDimension(125, 20));
		usernameField.setPreferredSize(new IntDimension(125, 20));
		usernameField.setEditable(true);
		usernameField.setDisplayAsPassword(false);
		usernameField.setMaxChars(25);
		usernameField.setWordWrap(false);
		
		pnlPassword = new JPanel();
		pnlPassword.setLocation(new IntPoint(0, 38));
		pnlPassword.setSize(new IntDimension(200, 30));
		var layout3:FlowLayout = new FlowLayout();
		layout3.setAlignment(AsWingConstants.RIGHT);
		pnlPassword.setLayout(layout3);
		
		lblPassword = new JLabel();
		lblPassword.setForeground(new ASColor(0xffffff, 1));
		lblPassword.setLocation(new IntPoint(11, 6));
		lblPassword.setSize(new IntDimension(54, 17));
		lblPassword.setText("Password:");
		
		passwordField = new JTextField();
		passwordField.setForeground(new ASColor(0xffffff, 1));
		passwordField.setBackground(new ASColor(0x333333, 1));
		passwordField.setLocation(new IntPoint(70, 5));
		passwordField.setSize(new IntDimension(125, 20));
		passwordField.setPreferredSize(new IntDimension(125, 20));
		passwordField.setEditable(true);
		passwordField.setDisplayAsPassword(true);
		passwordField.setMaxChars(25);
		passwordField.setWordWrap(false);
		
		pnlButtons = new JPanel();
		pnlButtons.setLocation(new IntPoint(0, 68));
		pnlButtons.setSize(new IntDimension(200, 22));
		var layout4:GridLayout = new GridLayout();
		layout4.setRows(1);
		layout4.setColumns(0);
		layout4.setHgap(25);
		pnlButtons.setLayout(layout4);
		
		btnRegister = new JButton();
		btnRegister.setLocation(new IntPoint(0, 0));
		btnRegister.setSize(new IntDimension(87, 22));
		btnRegister.setText("Register");
		
		btnConnect = new JButton();
		btnConnect.setLocation(new IntPoint(112, 0));
		btnConnect.setSize(new IntDimension(87, 22));
		btnConnect.setText("Connect");
		
		//component layoution
		append(pnlGroup);
		
		pnlGroup.append(pnlUsername);
		pnlGroup.append(pnlPassword);
		pnlGroup.append(pnlButtons);
		
		pnlUsername.append(lblUsername);
		pnlUsername.append(usernameField);
		
		pnlPassword.append(lblPassword);
		pnlPassword.append(passwordField);
		
		pnlButtons.append(btnRegister);
		pnlButtons.append(btnConnect);
		
	}
	
	//_________getters_________
	
	
	
	
	public function getUsernameField():JTextField{
		return usernameField;
	}
	
	
	
	public function getPasswordField():JTextField{
		return passwordField;
	}
	
	
	public function getBtnRegister():JButton{
		return btnRegister;
	}
	
	public function getBtnConnect():JButton{
		return btnConnect;
	}
	
	
}
}
