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
	private var gameScroller:JScrollPane;
	private var gameList:JList;
	private var btnJoinGame:JButton;
	private var btnCreateGame:JButton;
	private var chatLogScroller:JScrollPane;
	private var chatLog:JTextArea;
	private var rightSidePanel:JPanel;
	private var btnLogOut:JButton;
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
		pnlGames.setLocation(new IntPoint(0, 5));
		pnlGames.setSize(new IntDimension(150, 435));
		var layout1:SoftBoxLayout = new SoftBoxLayout();
		layout1.setAxis(AsWingConstants.VERTICAL);
		layout1.setAlign(AsWingConstants.LEFT);
		layout1.setGap(3);
		pnlGames.setLayout(layout1);
		
		gameScroller = new JScrollPane();
		gameScroller.setLocation(new IntPoint(0, 0));
		gameScroller.setSize(new IntDimension(150, 385));
		
		gameList = new JList();
		gameList.setForeground(new ASColor(0xffffff, 1));
		gameList.setBackground(new ASColor(0x333333, 1));
		gameList.setLocation(new IntPoint(0, 0));
		gameList.setSize(new IntDimension(150, 385));
		gameList.setPreferredSize(new IntDimension(150, 385));
		gameList.setSelectionMode(0);
		gameList.setPreferredCellWidthWhenNoCount(150);
		gameList.setVisibleCellWidth(150);
		gameList.setVisibleRowCount(50);
		
		btnJoinGame = new JButton();
		btnJoinGame.setLocation(new IntPoint(0, 418));
		btnJoinGame.setSize(new IntDimension(150, 22));
		btnJoinGame.setText("Join Selected Game");
		
		btnCreateGame = new JButton();
		btnCreateGame.setLocation(new IntPoint(0, 443));
		btnCreateGame.setSize(new IntDimension(150, 22));
		btnCreateGame.setText("Create Game");
		
		chatLogScroller = new JScrollPane();
		chatLogScroller.setLocation(new IntPoint(155, 0));
		chatLogScroller.setSize(new IntDimension(344, 445));
		chatLogScroller.setPreferredSize(new IntDimension(344, 445));
		
		chatLog = new JTextArea();
		chatLog.setForeground(new ASColor(0xffffff, 1));
		chatLog.setBackground(new ASColor(0x333333, 1));
		chatLog.setSize(new IntDimension(344, 445));
		chatLog.setWordWrap(true);
		
		rightSidePanel = new JPanel();
		rightSidePanel.setLocation(new IntPoint(504, 1));
		rightSidePanel.setSize(new IntDimension(125, 442));
		var layout2:SoftBoxLayout = new SoftBoxLayout();
		layout2.setAxis(AsWingConstants.VERTICAL);
		layout2.setAlign(AsWingConstants.TOP);
		layout2.setGap(0);
		rightSidePanel.setLayout(layout2);
		
		btnLogOut = new JButton();
		btnLogOut.setLocation(new IntPoint(0, 0));
		btnLogOut.setSize(new IntDimension(126, 22));
		btnLogOut.setText("Log Out");
		
		userListScroller = new JScrollPane();
		userListScroller.setLocation(new IntPoint(0, 25));
		userListScroller.setSize(new IntDimension(126, 420));
		userListScroller.setPreferredSize(new IntDimension(126, 420));
		
		userList = new JTextField();
		userList.setForeground(new ASColor(0xffffff, 1));
		userList.setBackground(new ASColor(0x333333, 1));
		userList.setLocation(new IntPoint(0, 0));
		userList.setSize(new IntDimension(110, 420));
		userList.setPreferredSize(new IntDimension(110, 420));
		userList.setEditable(false);
		userList.setWordWrap(false);
		
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
		displayPanel.append(rightSidePanel);
		
		pnlGames.append(gameScroller);
		pnlGames.append(btnJoinGame);
		pnlGames.append(btnCreateGame);
		
		rightSidePanel.append(btnLogOut);
		rightSidePanel.append(userListScroller);
		
		gameScroller.setView(gameList);
		gameScroller.setVerticalScrollBarPolicy(JScrollPane.SCROLLBAR_AS_NEEDED);
		
		chatLogScroller.setView(chatLog);
		chatLogScroller.setVerticalScrollBarPolicy(JScrollPane.SCROLLBAR_ALWAYS);
		
		userListScroller.setView(userList);
		userListScroller.setVerticalScrollBarPolicy(JScrollPane.SCROLLBAR_AS_NEEDED);
		
	}
	
	//_________getters_________
	
	
	
	
	public function getGameList():JList{
		return gameList;
	}
	
	public function getBtnJoinGame():JButton{
		return btnJoinGame;
	}
	
	public function getBtnCreateGame():JButton{
		return btnCreateGame;
	}
	
	
	public function getChatLog():JTextArea{
		return chatLog;
	}
	
	
	public function getBtnLogOut():JButton{
		return btnLogOut;
	}
	
	
	public function getUserList():JTextField{
		return userList;
	}
	
	
	public function getChatBox():JTextField{
		return chatBox;
	}
	
	
}
}
