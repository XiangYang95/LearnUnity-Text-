using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour {
    Text text;
    private enum State { cell, sheets_0, mirror, lock_0, sheets_1, cell_mirror, lock_1, corridor_0, stairs_0, floor, closet_door, corridor_1, stairs_1, 
		 in_closet, corridor_2, stairs_2, corridor_3, outside, freedom}
    bool prev;
	int checkStairs1;
	bool checkStairs2, checkCorridor2;
    private State myState;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        myState = State.cell;
        prev = true;
		checkStairs1 = 0;
		checkStairs2 = false; checkCorridor2 = false;
	}
	
	// Update is called once per frame
	void Update () {
        print(myState);
		if (myState == State.cell) {
			cell ();
		} else if (myState == State.sheets_0) {
			sheets_0 ();
		} else if (myState == State.mirror) {
			mirror ();
		} else if (myState == State.lock_0) {
			lock_0 ();
		} else if (myState == State.cell_mirror) {
			cell_mirror ();
		} else if (myState == State.sheets_1) {
			sheets_1 ();
		} else if (myState == State.lock_1) {
			lock_1 ();
		} else if (myState == State.corridor_0) {
			corridor_0 ();
		} else if (myState == State.floor) {
			floor ();
		} else if (myState == State.stairs_0) {
			stairs_0 ();
		} else if (myState == State.floor) {
			floor ();
		} else if (myState == State.closet_door) {
			closet_door ();
		} else if (myState == State.corridor_1) {
			corridor_1 ();
		} else if (myState == State.stairs_1) {
			stairs_1 ();
		} else if (myState == State.in_closet) {
			in_closet ();
		} else if (myState == State.corridor_2) {
			corridor_2 ();
		} else if (myState == State.stairs_2) {
			stairs_2 ();
		} else if (myState == State.corridor_3) {
			corridor_3 ();
		} else if (myState == State.outside) {
			outside ();
		} else {
			text.text = "!!!!!FREEDOM!!!!!";
			text.alignment = TextAnchor.MiddleCenter;
			text.fontSize = 50;
		}
    }

    private void cell()
    {
        text.fontSize = 27;
        text.text = "I am stuck in a cell. Where the f**k am I? "
                + "I could see the sheets on the bed, "
                + "a mirror on the wall,"
                + " and a locked door.\n\n"
                + "Press S to view sheets. Press M to view Mirror. Press L to go to door";
        if (Input.GetKeyDown(KeyCode.S)) { myState = State.sheets_0; }
        else if (Input.GetKeyDown(KeyCode.M)) { myState = State.mirror; }
        else if (Input.GetKeyDown(KeyCode.L)) { myState = State.lock_0; }
    }

    private void sheets_0()
    {
        text.text = "Looking at the sheets tell me nothing. "
                + "I might as well look for other clues.\n\n "
                + "Press R to return to cell.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = State.cell; }
    }

    private void lock_0()
    {
        text.text = "Going to the door now solves nothing, "
                + "since I still can't figure out how to get out of here.\n\n"
                + "Press R to return to cell.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = State.cell; }
    }

    private void mirror()
    {
        text.text = "The mirror looks funny. "
                + "Maybe I can do something about it.\n\n"
                + "Press R to return to cell. Press T to grab Mirror.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = State.cell; }
        else if (Input.GetKeyDown(KeyCode.T)) { myState = State.cell_mirror; }
    }

    private void cell_mirror()
    {
        if (prev)
        {
            text.text = "Well now that I'm holding this mirror, "
                    + "Maybe I should do something about it, "
                    + "like maybe wipe the mirror with the sheet?\n\n"
                    + "Press R to return to cell. Press S to grab Sheet.";
            if (Input.GetKeyDown(KeyCode.R)) { myState = State.cell; }
            else if (Input.GetKeyDown(KeyCode.S)) { myState = State.sheets_1; }
        }
        else
        {
            text.text = "There's the key.... I'm so stupid..."
                    + "Should have just looked at the back of the mirror. "
                    + "\n\n"
                    + "Press R to return to cell. Press L to go to the door.";
            if (Input.GetKeyDown(KeyCode.R)) { myState = State.cell; }
            else if (Input.GetKeyDown(KeyCode.L)) { myState = State.lock_1; }
        }
    }

    private void sheets_1()
    {
        text.text = "Wiping the mirror doesn't work. "
                   + "Nothing is popping out. But wait. There's something behind the mirror. "
                   + "(Take a look at the back of the mirror) Ohh. \n\n"
                   + "Press R to return to mirror.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = State.cell_mirror; prev = false; }
    
    }

    private void lock_1()
    {
        text.text = "Yup the door opens. "
                   + "And now I'm free from this prison room. "
                   + "\n\n"
                   + "Press O for open door";
        if (Input.GetKeyDown(KeyCode.O)) { myState = State.corridor_0; }

    }

	private void corridor_0()
	{
		text.text = "Haiz~~Now we're at the corridor. "
			+ "So right now, I can either go down the stairs on my left, " 
			+ "go on a straight path in front of me or go to the closet "
			+ "\n\n"
			+ "Press S for stairs, F for the path and C for the closet";
		if (Input.GetKeyDown(KeyCode.S)) { myState = State.stairs_0; }
		if (Input.GetKeyDown(KeyCode.F)) { myState = State.floor; }
		if (Input.GetKeyDown(KeyCode.C)) { myState = State.closet_door; }
	}

	private void stairs_0()
	{
		text.text = "There's no way out of here... "
			+ "\n\n"
			+ "Press R to return.";
		if (Input.GetKeyDown(KeyCode.R)) { myState = State.corridor_0; }
	}

	private void closet_door()
	{
		text.text = "The door can't open yet. Need something to open it. "
			+ "\n\n"
			+ "Press R to return.";
		if (Input.GetKeyDown(KeyCode.R)) { myState = State.corridor_0; }
	}

	private void floor()
	{
		text.text = "There's nothing at the end of this path. But I notice a hairclip on the floor. " 
			+ "Seems like these people also lock girls up here. These bastards."
			+ "\n\n"
			+ "Press H to grab the hairclip.";
		if (Input.GetKeyDown(KeyCode.H)) { myState = State.corridor_1; }
	}

	private void corridor_1()
	{
		if (checkStairs1 == 0) {
			text.text = "Okay now what should I do with this hairpin? Go up the stairs again to see if there are other clues or "
			+ "or pick the closet."
			+ "\n\n"
			+ "Press S for stairs, P for picking closet";
			if (Input.GetKeyDown (KeyCode.S)) {
				myState = State.stairs_1;
			}
			if (Input.GetKeyDown (KeyCode.P)) {
				myState = State.in_closet;
			}
		} else {
			text.text = "Well obviously I have to pick the closet. "
				+ "\n\n"
				+ "Press P for picking closet";
			if (Input.GetKeyDown (KeyCode.P)) {
				myState = State.in_closet;
			}
		}
	}

	private void stairs_1()
	{
		text.text = "Come on man. You already look up here before and you should have known that nothing's here ==. " 
			+ "It's redundant to come here......."
			+ "\n\n"
			+ "Press R to return.";
		if (Input.GetKeyDown(KeyCode.R)) { myState = State.corridor_1; }
		checkStairs1 = 1;
	}

	private void in_closet()
	{
		if (checkCorridor2 == false) {
			text.text = "Now I see that there's a cleaner's dress hanging in the closet..."
			+ "Now, should I just wear this ugly dress and feel stupid or return to the corridor and think of some other ways."
			+ "\n\n"
			+ "Press R to return or D to dress.";
			if (Input.GetKeyDown (KeyCode.R)) {
				myState = State.corridor_2;
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				myState = State.corridor_3;
			}
		} else {

			text.text = "Just wear the goddamn dress...."
			+ "\n\n"
			+ "Press D to dress.";
			if (Input.GetKeyDown (KeyCode.D)) {
				myState = State.corridor_3;
			}
		}
	}

	private void corridor_2()
	{
		if (checkStairs2 == false) {
			
			text.text = "Now that I'm here again what can I do? Go up the stairs again (Please don't do this) "
			+ "or go back to the closet and just wear the hideous dress?"
			+ "\n\n"
			+ "Press R to return to closet or S to stairs.";
			if (Input.GetKeyDown (KeyCode.R)) {
				myState = State.in_closet;
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				myState = State.stairs_2;
			}
		} else {
			text.text = "(More).................................................................................."
				+ "\n\n"
				+ "Press R to return.";
			if (Input.GetKeyDown (KeyCode.R)) {
				myState = State.in_closet;
			}
			checkCorridor2 = true;
		}
	}

	private void stairs_2()
	{
		text.text = ".................................................................................."
			+ "\n\n"
			+ "Press R to return.";
		if (Input.GetKeyDown(KeyCode.R)) { myState = State.corridor_2; }
		checkStairs2 = true;

	}

	private void corridor_3()
	{
		text.text = "After wearing the dress and thinking about how stupid I look, " 
			+ "I notice that there's a sliver of moonlight coming from the gaps of the closet."
			+ "\n\n"
			+ "Press P to push open the closet.";
		if (Input.GetKeyDown(KeyCode.P)) { myState = State.outside; }
	}

	private void outside()
	{
		text.text = "It really leads to outside. I'm freeeeee!!"
			+ "\n\n"
			+ "Press F for Freedom.";
		if (Input.GetKeyDown(KeyCode.F)) { myState = State.freedom; }
	}
}
