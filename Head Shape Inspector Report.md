**Topic** : Serious game for medical training and visual assessment 
of head deformities in infants 

**Name** : Piotr Warkocki

**Game Name** : *Head Shape Inspector* 

**Supervisor** : Doctor Helena Daniela Ribeiro Torres


**Activities Report**
5th February 2024 – 15th June 2024

+----------------------------------------------------------------------------------------------------------------------------------------------------------+

**Abstract:**

This report presents the development and implementation of *“Head Shape Inspector”*, an educational game designed to train healthcare professionals and students in diagnosing and analyzing cranial deformities in infants. 
Cranial deformities, such as plagiocephaly, brachycephaly, and scaphocephaly, affect approximately 20% of infants. Early detection of such deformities is very important for intervention as it can lead to effective treatments before further complications occur resulting in much needed surgery. 
This report details the methodologies employed, challenges encountered, and solutions implemented during the development process. The *“Head Shape Inspector”* game represents a significant advancement in medical education tools, providing an innovative approach to improving diagnostic proficiency in cranial deformities. 

+----------------------------------------------------------------------------------------------------------------------------------------------------------+

**Contents:**
1.	Introduction:	
  
2.	Goals:	
	
3.	Activities:	

    3.1.	State of the Art Reseach:	

    3.2.	Design of the application:	

    3.3.	Implementation of the application:	

4.	Unity Hierarchy:	

5.	Conclusion:

+----------------------------------------------------------------------------------------------------------------------------------------------------------+


**Introduction:**

Cranial deformations, such as plagiocephaly, brachycephaly, and scaphocephaly, are surprisingly common, affecting up to 20% of infants. These deformations can arise from various factors, including in-utero positioning, birth trauma, and prolonged time spent in a single position postnatally. Understanding and analyzing cranial deformations is crucial for early intervention. 
Accurate identification can lead to effective treatments, such as repositioning therapy, physical therapy, or the use of corrective helmets. Early intervention helps prevent further complications and significantly improves the quality of life and developmental outcomes for affected infants. 
*“Head Shape Inspector”* provides a platform to practice and refine the skills necessary for diagnosing and managing cranial deformations. Its easy-to-follow interface and level progression makes it possible for the user to solely focus on learning and diagnosing each deformation presented to them in a variety of different levels. 
With serious games becoming more and more popular for educational purposes, “Head Shape Inspector” hopes to provide a more engaging and practical way of learning. Its main goal is to be used as a tool for physicians and medical students to further enhance their knowledge on cranial deformations.

+----------------------------------------------------------------------------------------------------------------------------------------------------------+

**Goals:**
State-of-the-art Research: 
The goal was to research the current state of serious games in relation to the educational aspect. Finding affective ways for teaching through games, and making the learning process as engaging as possible.

Design of the Application: 
The goal here was to design the application based on the information drawn out in the research stage. All UI elements and game components would have to be created to ensure the game follows a similar graphical pattern to provide a smooth experience for the user.  

Implementation of the Application: 
The last goal of this project was to implement all components and ideas into a working application. All features needed for the game to be a usable tool for learning would have      to be carefully put together.

+----------------------------------------------------------------------------------------------------------------------------------------------------------+

**Activities:**
**State-of-the-art Research:**

In this activity the first goal of the project was achieved. The State-of-the-art was researched and ideas for the application were made. After talks with my supervisor, a mobile application approach was chosen for the project as it would be the most accessible mode for everyone. It would allow for constant practice and would allow the user to learn on the go, no matter where the person is.

+----------------------------------------------------------------------------------------------------------------------------------------------------------+

**Design of the Application:**
Once the idea for the game was drawn out and thoroughly thought about, the 	next step was to design the application. This activity focused on achieving the second goal of this project. All UI and game elements were created using Photoshop and sourced from the internet. Each level was designed with the user in mind ensuring that education was the number one priority, and no distractions or confusions were present during the learning process. All 3D models and their 	corresponding top-down views have been sourced by 2AI.  
Some design features can be seen in Figure 1 and Figure 2 below: 
 
  
![image](https://github.com/PiotrWarkocki03/HeadShapeInspector/assets/148338420/28ffae2a-b9a5-43d5-9969-83bef912f416)

Figure 1 – Designed Main Menu for “Head Shape Inspector”.

•	Settings Button to access Game Settings. 

•	Information Button to access Information about the game and how to play it. 

•	About Button to access Information about each type of deformity that is in the game. 

•	Play Button to start playing the game. 

•	High score Button to access players high score and compare scores with other users.  

![image](https://github.com/PiotrWarkocki03/HeadShapeInspector/assets/148338420/52091314-79b4-485f-a57e-08605b8b2c77)

 
Figure 2 – Difficulty Selection

•	Easy, Medium and Hard difficulty is displayed here. 

•	Stars and “0/60” text display number of stars collected in each difficulty. 

•	Lock Icon shows player that the levels are not accessible yet.


+----------------------------------------------------------------------------------------------------------------------------------------------------------+

**Implementation of the Application:**
After the design for the application was created, the final goal of the project was tackled. Implementation of the project was made possible using the Unity Game Engine. All needed features were made possible using C# Scripts. 
Examples where such scripts were needed to make this possible are:  
•	Rotating and zooming in on each 3D model of a cranial deformation. 

•	Interaction with answers and all UI elements. 

•	Navigation between levels. 

All levels and menus were linked to each other to create an easy to navigate environment ensuring yet again that learning is the primary focus. 
Some implementations can be seen in Figure 3 Figure 4 below: 

![image](https://github.com/PiotrWarkocki03/HeadShapeInspector/assets/148338420/f8e8cb6f-fbd6-4678-b83e-0672cd6309f6)

Figure 3 - Video Level:

Video level allows the user to watch an educational video and later answer questions based on the video shown. 

•	Video Panel to display video for each appropriate level. 

•	Volume slider to change video volume. 

•	“Rewind”,” Pause", and Fast forward” buttons to interact with videos    playback abilities. 

•	Stars to display stars received from level. 

•	Menu button to pause game and access features such as return to menu, information about the game, information about each deformity and quitting game.

![image](https://github.com/PiotrWarkocki03/HeadShapeInspector/assets/148338420/a4382b45-c7fb-4bd8-b924-91b2229799cd)

Figure 4 - Cranial Deformation Level: 

Diagnosis and Analysis of an infant with cranial deformation is possible within this level. The user can rotate the head and zoom in to analyze the deformity. Once the user has an idea of what type of deformity it is they can select their answer and feedback will be given to them.
•	3D model of the head can be seen for diagnosis.

•	5 possible answer buttons for user to choose from. 

•	Level Text displaying current game level. 

•	Timer displaying time spent in current level. 

•	Hint button to give player a hint about the given deformation which included a 2D top view of the infant's head alongside some common information needed for analysis. 

•	Menu button to pause game and access features such as return to menu, information about the game, information about each deformity and quitting game. 

The hint panel allows player to get an in-depth view of the cranial deformity if they desire.
They can receive a 2d top-down view of the cranial deformity with information on the deformity provided.

![image](https://github.com/PiotrWarkocki03/HeadShapeInspector/assets/148338420/9b8a4e4b-612b-4841-bc72-1224986068c2)

Figure 5 – 2D- View Hint Panel:
•	Cephalic Ratio information provided.

•	Cranial Vault Asymmetry Index provided

•	Diagonal lengths provided

•	Width and Length measurements provided.

Player feedback is very important in serious games. The player needs feedback to be able to determine where they went wrong or where they need to improve.
Feedback in *“Head Shape Inspector”* is given after a player completes a level.

![image](https://github.com/PiotrWarkocki03/HeadShapeInspector/assets/148338420/665b931f-fc06-474a-8eda-62b80b88c58a)

Figure 6.1 Correct Feedback:                               
-Stars received from level will be displayed here.                                                                                                      
-Information about actions taken in level will be shown and a linewill be crossed through the text ifthe action has been performed.
-“Next” and “Menu” button for player to determine their next actions.

![image](https://github.com/PiotrWarkocki03/HeadShapeInspector/assets/148338420/d922f9ee-c8a6-499b-9550-9f2d789d2d15)

Figure 6.2 Incorrect Feedback: 
-Incorrect panel will be displayed if player does not receive enough stars in the level

+----------------------------------------------------------------------------------------------------------------------------------------------------------+

**Unity Hierarchy:**

The hierarchy for the cranial deformity levels consists of a lot of different components, but the most important ones are:

•	2D canvas – used to display all UI Components. 

•	Camera – renders the 3D model onto the 2D canvas.

•	Raw Image 2D – displays a texture which in this case is the 3D model of the babies’ heads.

•	3D model – Each level displays a different cranial deformity 3D model.

•	Questionnaire Manager game object – Contains the script for question-and-answer functionality.


The hierarchy for the questionnaire levels consists of less than the cranial deformity questions.

•	2D canvas – used to display all UI Components. 

•	3 different question panels are displayed here which are used within the level

•	Camera is not needed in this level as there are no objects needed to be rendered in.

•	Questionnaire Manager game object – Contains the script for question-and-answer functionality.

+----------------------------------------------------------------------------------------------------------------------------------------------------------+

**Conclusion:**

In conclusion, the "Head Shape Inspector" game stands as a significant contribution to the field of medical education, offering an innovative and interactive tool for training healthcare professionals and students in the diagnosis and analysis of cranial deformities in infants. 

This project highlights the importance of early detection and intervention in preventing developmental complications associated with cranial deformities. 

Using Unity, the game combines realistic 3D models, videos describing important factors, and comprehensive case studies to create a robust learning platform. The use of Unity was instrumental in achieving high-quality graphics and interactive elements, making the educational experience engaging and effective. 

The development process, from conceptualization to deployment, involved careful planning, design, and iteration, ensuring a high-quality educational experience. 
 
Moving forward, the game can be further enhanced with additional features, more diverse case studies, and integration with emerging technologies such as virtual reality (VR) and artificial intelligence (AI). By continuously updating and refining the game, it can remain a valuable resource for improving the quality of care provided to infants with cranial deformities. 

+----------------------------------------------------------------------------------------------------------------------------------------------------------+
