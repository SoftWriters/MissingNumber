import java.awt.TextArea;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextArea;

/**
 * 
 * @author Bryson Hair
 *
 */
public class MainWindow extends JFrame
{
	public MainWindow()
	{
		this.setTitle("Find Missing Sequence Number");
		this.setSize(1000,1000);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.getContentPane().setLayout(new BoxLayout(getContentPane(), BoxLayout.Y_AXIS));
		
		addComponents();
		
		this.setVisible(true);
	}
	
	private void addComponents()
	{
		JTextArea textArea = new JTextArea();
		textArea.setRows(10);
		textArea.setColumns(40);
		
		JButton button = new JButton("Select File");
		button.addActionListener(new ActionListener(){

			@Override
			public void actionPerformed(ActionEvent event) {
				JFileChooser fc = new JFileChooser();
				int returnVal = fc.showOpenDialog(button);
				if(returnVal == JFileChooser.APPROVE_OPTION)
				{
					File file = fc.getSelectedFile();
					List<String> lines = null;
					try {
						lines = Files.readAllLines(file.toPath());
					} catch (IOException exception) {
						// TODO Auto-generated catch block
						exception.printStackTrace();
					}
					
					ArrayList<int []> intList = new ArrayList<int []>();
					//Convert the list of strings into a list of sorted int arrays
					for(int i = 0; i < lines.size(); i++)
					{
						String [] strArray = lines.get(i).split(",");
						int [] intArray = new int [strArray.length];
						
						for(int j = 0; j < strArray.length; j++)
						{
							intArray[j] = Integer.parseInt(strArray[j]);
						}
						
						Arrays.sort(intArray);
						intList.add(intArray);
					}
					
					int [] missingNumbers = findMissingNumbers(intList);
					String str = "";
					for(int i = 0; i < missingNumbers.length; i++)
					{
						str += missingNumbers[i] + "\n";
					}
					
					textArea.setText(str);
				}
			}
		});
		
		this.add(button);
		this.add(textArea);
	}
	
	private int [] findMissingNumbers(ArrayList<int []> intArrays)
	{
		int [] ints = new int [intArrays.size()];
		
		//find and return an array of missing ints
		for(int i = 0; i < intArrays.size(); i++)
		{
			int [] arr = intArrays.get(i);
			int curValue = arr[0];
			for(int j = 1; j < arr.length; j++)
			{
				if(arr[j] - 1 == curValue)
				{
					curValue = arr[j];
				}
				else
				{
					ints[i] = curValue + 1;
				}
			}
		}
		
		return ints;
	}
}