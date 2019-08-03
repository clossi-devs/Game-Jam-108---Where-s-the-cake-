using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StringManager : MonoBehaviour
{
    /// <summary>
    /// Take in a string and return a string with all characters
    /// upper case.
    /// </summary>
    /// <param name="s">Takes in a string.</param>
    /// <returns>Returns a string with all characters upper case.</returns>
    public string UpperString (string s)
    {
    	s = s.ToUpper();

    	return s;
    }

    /// <summary>
    /// Turn all characters in the string to lowercase.
    /// </summary>
    /// <param name="s">Takes in a string.</param>
    /// <returns>Returns a string with all characters lower case.</returns>
    public string LowerString (string s)
    {
    	s = s.ToLower();

    	return s;
    }

    /// <summary>
    /// Takes in a string and returns a char array of all the
    /// characters in the string.
    /// </summary>
    /// <param name="s">Takes in a string</param>
    /// <returns>Returns a char array of all the char in the given string.</returns>
    public char[] StringToCharArray (string s)
    {
    	char[] arr = s.ToCharArray();

    	return arr;
    }

    /// <summary>
    /// Takes in a string and returns a list of characters.
    /// </summary>
    /// <param name="s">Takes in a string.</param>
    /// <returns>Returns a list of char of the char in the given string.</returns>
    public List<char> StringToCharList (string s)
    {
    	List<char> list = new List<char>();

    	for(int i=0; i<s.Length; i++) { list.Add(s[i]); }

    	return list;
    }

    /// <summary>
    /// Takes in a char list and converts it to a string.
    /// </summary>
    /// <param name="list">Takes in a list of char.</param>
    /// <returns>Returns a string containing all the char that was in the list.
    /// If nothing was in the list, returns a blank string.</returns>
    public string CharListToString (List<char> list)
    {
    	string s = "";

    	for (int i=0; i<list.Count; i++) { s = s + list[i].ToString(); }

        if (s == "")
        { Debug.Log("Nothing found in the list<char> given. : CharListToString function in StringManager.cs"); }

    	return s;
    }
}
