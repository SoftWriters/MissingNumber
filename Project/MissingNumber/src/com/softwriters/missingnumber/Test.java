package com.softwriters.missingnumber;

import java.io.File;

/**
 *
 * @author Isaac
 */
public class Test 
{
    /**
     * Main class to test MissingNumber class
     * @param args 
     */
    public static void main(String[] args)
    {
        File f;
        if(args.length > 0)
            f = new File(args[0]);
        else if(new File("sample.txt").canRead())
            f = new File("sample.txt");
        else
            f = null;
        MissingNumber mn = new MissingNumber(f);
        if(mn.openFile())
        {
            while(mn.hasLine())
            {
                if(mn.canFindMissingNumber())
                    System.out.println(mn.getMissingNumber());
            }
        }
    }
}
