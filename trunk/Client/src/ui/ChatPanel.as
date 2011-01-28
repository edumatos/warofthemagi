package ui{

import org.aswing.*;
import org.aswing.border.*;
import org.aswing.geom.*;
import org.aswing.colorchooser.*;
import org.aswing.ext.*;

/**
 * ChatPanel
 */
public class ChatPanel extends JPanel{
	
	//members define
	private var displayPanel:JPanel;
	private var pnlGames:JPanel;
	private var btnLogOut:JButton;
	private var gameScroller:JScrollPane;
	private var gameList:JList;
	private var chatLogScroller:JScrollPane;
	private var chatLog:JTextField;
	private var userListScroller:JScrollPane;
	private var userList:JTextField;
	private var chatLabel:JLabel;
	private var chatBox:JTextField;
	
	/**
	 * ChatPanel Constructor
	 */
	public function ChatPanel(){
		//component creation
		setSize(new IntDimension(640, 480));
		setPreferredSize(new IntDimension(640, 480));
		
		displayPanel = new JPanel();
		displayPanel.setLocation(new IntPoint(5, 5));
		displayPanel.setSize(new IntDimension(630, 445));
		displayPanel.setPreferredSize(new IntDimension(630, 445));
		var layout0:FlowLayout = new FlowLayout();
		layout0.setAlignment(AsWingConstants.LEFT);
		layout0.setHgap(5);
		layout0.setVgap(5);
		layout0.setMargin(false);
		displayPanel.setLayout(layout0);
		
		pnlGames = new JPanel();
		pnlGames.setLocation(new IntPoint(0, 2));
		pnlGames.setSize(new IntDimension(150, 440));
		var layout1:SoftBoxLayout = new SoftBoxLayout();
		layout1.setAxis(AsWingConstants.VERTICAL);
		layout1.setAlign(AsWingConstants.LEFT);
		layout1.setGap(3);
		pnlGames.setLayout(layout1);
		
		btnLogOut = new JButton();
		btnLogOut.setLocation(new IntPoint(0, 0));
		btnLogOut.setSize(new IntDimension(150, 22));
		btnLogOut.setText("Log Out");
		
		gameScroller = new JScrollPane();
		gameScroller.setLocation(new IntPoint(0, 25));
		gameScroller.setSize(new IntDimension(150, 415));
		
		gameList = new JList();
		gameList.setBackground(new ASColor(0x333333, 1));
		gameList.setLocation(new IntPoint(0, 0));
		gameList.setSize(new IntDimension(150, 415));
		gameList.setPreferredSize(new IntDimension(150, 415));
		gameList.setSelectionMode(0);
		gameList.setPreferredCellWidthWhenNoCount(150);
		gameList.setVisibleCellWidth(150);
		gameList.setVisibleRowCount(100);
		
		chatLogScroller = new JScrollPane();
		chatLogScroller.setLocation(new IntPoint(155, 0));
		chatLogScroller.setSize(new IntDimension(344, 445));
		
		chatLog = new JTextField();
		chatLog.setForeground(new ASColor(0xffffff, 1));
		chatLog.setBackground(new ASColor(0x333333, 1));
		chatLog.setLocation(new IntPoint(0, 0));
		chatLog.setSize(new IntDimension(344, 445));
		chatLog.setPreferredSize(new IntDimension(344, 445));
		chatLog.setColumns(42);
		chatLog.setEditable(false);
		chatLog.setWordWrap(true);
		
		userListScroller = new JScrollPane();
		userListScroller.setLocation(new IntPoint(504, 0));
		userListScroller.setSize(new IntDimension(125, 445));
		
		userList = new JTextField();
		userList.setForeground(new ASColor(0xffffff, 1));
		userList.setBackground(new ASColor(0x333333, 1));
		userList.setLocation(new IntPoint(504, 0));
		userList.setSize(new IntDimension(125, 445));
		userList.setPreferredSize(new IntDimension(125, 445));
		userList.setEditable(false);
		
		chatLabel = new JLabel();
		chatLabel.setForeground(new ASColor(0xffffff, 1));
		chatLabel.setLocation(new IntPoint(5, 460));
		chatLabel.setSize(new IntDimension(31, 17));
		chatLabel.setText("Chat:");
		
		chatBox = new JTextField();
		chatBox.setForeground(new ASColor(0xffffff, 1));
		chatBox.setBackground(new ASColor(0x333333, 1));
		chatBox.setLocation(new IntPoint(41, 455));
		chatBox.setSize(new IntDimension(592, 21));
		chatBox.setColumns(73);
		
		//component layoution
		append(displayPanel);
		append(chatLabel);
		append(chatBox);
		
		displayPanel.append(pnlGames);
		displayPanel.append(chatLogScroller);
		displayPanel.append(userListScroller);
		
		pnlGames.append(btnLogOut);
		pnlGames.append(gameScroller);
		
		gameScroller.append(gameList);
		
		chatLogScroller.append(chatLog);
		
		userListScroller.append(userList);
		
	}
	
	//_________getters_________
	
	
	
	public function getBtnLogOut():JButton{
		return btnLogOut;
	}
	
	
	public function getGameList():JList{
		return gameList;
	}
	
	
	public function getChatLog():JTextField{
		return chatLog;
	}
	
	
	public function getUserList():JTextField{
		return userList;
	}
	
	
	public function getChatBox():JTextField{
		return chatBox;
	}
	
	
}
}
