package com.softwriters.missingnumber;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.Collections;
import java.util.Vector;
import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.filechooser.FileNameExtensionFilter;

/**
 *
 * @author Isaac Hammon
 */
public class MissingNumber 
{
    private BufferedReader br;
    private File f;
    private String line;
    private int missingNumber;
    /**
     * Empty constructor
     */
    public MissingNumber()
    {
        this(null);
    }
    /**
     * Constructor
     * @param f The file to be opened
     */
    public MissingNumber(File f)
    {
        if(f != null)
            this.f = f.getAbsoluteFile();
        else
            this.f = getFile();
        
    }
    /**
     * Method to determine if the file in the BufferedReader still has a line to be read
     * @return True if br.readLine() != null else False
     */
    public boolean hasLine()
    {
        try 
        {
            if((line = br.readLine()) != null)
                return true;
            else
                return false;
        }
        catch (IOException ex) 
        {
            JOptionPane.showMessageDialog(null, ex.toString(), "Error Reading File",JOptionPane.ERROR_MESSAGE);
            return false;
        }
    }
    
    /**
     * If the user does not supply a file to be opened in the constructor this method allows the user to select a file in a JFileChooser.
     * @return File selected file from JFileChooser
     */
    private File getFile()
    {
        JFileChooser jfc = new JFileChooser();
        jfc.setFileFilter(new FileNameExtensionFilter("*.txt","txt"));
        
        int retVal = jfc.showOpenDialog(null);
        if(retVal == JFileChooser.APPROVE_OPTION)
            return jfc.getSelectedFile();
        else
            return null;
    }
    
    /**
     * Reads file into BufferedReader
     * @return True if file is successfully read into BufferedReader else false.
     */
    public boolean openFile()
    {
        try 
        {
            br = new BufferedReader(new FileReader(f));
            return true;
        }
        catch (FileNotFoundException ex) 
        {
            JOptionPane.showMessageDialog(null, ex.toString(), "File Not Found", JOptionPane.ERROR_MESSAGE);
        }
        return false;
    }
    
    /**
     * Iterates through the numbers in the current line
     * @return True if 
     */
    public boolean canFindMissingNumber()
    {
        if(!line.replace(" ", "").equals(""))
        {
            String[] array = line.split(",");
            Vector<Integer> v = new Vector<Integer>();
            for(String a: array)
            {
                v.add(Integer.parseInt(a));
            }
            Collections.sort(v);
            for(int i = 0; i < v.size(); i++)
            {
                if(v.elementAt(i) + 1 != v.elementAt(i+1))
                {
                    missingNumber = v.elementAt(i)+1;
                    return true;
                }
            }
            return false;
        }
        else
            return false;
    }
    /**
     * Gets the current missing number
     * @return missingNumber
     */
    public int getMissingNumber()
    {
        return missingNumber;
    }
}
