   M S B A M L   `   `   `  ����C  ?Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalendarCalendar  5   	       Calendar.AddWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Calendar     5   	     � Title$  	AddWindow��5   	   $��375.241��6   $	��416��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ addLabel��5
      $��	ADD EVENT��6"   $
��Left=�66   $��50��6Q   $��
117,10,0,0q�6]   $	��Top=�6q   $	��181��6�   $��24(�6�   $��Center=�6�   �� 5   
   -   5        $ dayLabel��5      $	��Day��6"   $
��Left=�60   $��28��6K   $��	50,70,0,0q�6X   $	��Top=�6k   $��50��6�   �� 5   
   -   5        $ 
monthLabel��5      $��Month��6$   $
��Left=�64   $��28��6O   $��
50,101,0,0q�6[   $	��Top=�6o   $��50��6�   �� 5   
   -   5        $ 	yearLabel��5      $
��Year��6#   $
��Left=�62   $��28��6M   $��
50,130,0,0q�6Y   $	��Top=�6m   $��50��6�   �� 5   
   -   5         ��Name$ startDayTextBox��5      $
��Left=�6+   $��28��6F   $��
149,70,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $��62��6�   $��Center=�6�   �� 5   
   -   5        $ startMonthTextBox��5      $
��Left=�6-   $��28��6H   $��149,101,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $��62��6�   $��Center=�6�   �� 5   
   -   5        $ startYearTextBox��5      $
��Left=�6,   $��28��6G   $��149,132,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $��62��6�   $��Center=�6�   �� 5   
   -   5        $ informationLabel��5      $��Information��6*   $
��Left=�6@   $��28��6[   $��
50,163,0,0q�6g   $	��Top=�6{   $��77��6�   �� 5   
   -	   5        $ informationTextBox��5      $
��Left=�6.   $��28��6I   $��149,163,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��181��6�   $��Center=�6�   �� 5   
   -
   5         ��Name$ priorityCheckBox��5      $��Priority��6-   $
��Left=�6@   $��28��6[   $��149,194,0,0q�6g   $	��Top=�6|   $��77��6�   $��Center=�6�   �� 5   
   -   5         ��Name$ 
saveButton��5      $
��SAVE��6%   $
��Left=�64   $��30��6O   $��
91,286,0,0q�6[   $	��Top=�6o   $��90��6�    �� 	IsDefault . 6�   �� 5   
   -   5        $ cancelButton��5      $��CANCEL��6'   $
��Left=�68   $��30��6S   $��240,286,0,0q�6_   $	��Top=�6t   $��90��6�    �� IsCancel . 6�   �� 5   
   -   5        $ endDayTextBox��5      $
��Left=�6)   $��28��6D   $��
252,70,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $��62��6�   {�.  $��Center=�6�   �� 5   
   -   5        $ endMonthTextBox��5      $
��Left=�6+   $��28��6F   $��252,101,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $��62��6�   {�.  $��Center=�6�   �� 5   
   -   5        $ endYearTextBox��5      $
��Left=�6*   $��24��6E   $��252,134,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $��62��6�   {�.  $��Center=�6�   �� 5   
   -   5         ��Name$ 
periodList��5      $
��Left=�6'   $��24��6B   $��181,227,0,0q�6N   $	��Top=�6c   $	��117��6{   {�.  	 �� DisplayMemberPath$	 
TimeString��6�   
 �� SelectedValuePath$
 	TimeValue��6�   �� 5   
   -   5        $ longtermEventCheckBox��5      $��Longterm Event��62   $
��Left=�6K   $	��Top=�6f   $��
248,50,0,0q�6~   6�   �� 5   
   -   5        $ periodicEventCheckBox��5      $��Periodic Event��62   $
��Left=�6K   $��24��6f   $��
50,227,0,0q�6r   $	��Top=�6�   $	��101��6�   6�   5      5      