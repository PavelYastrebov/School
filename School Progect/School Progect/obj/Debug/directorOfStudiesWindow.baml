   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5   	   H DMahApps.Metro, Version=1.0.0.6, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	    School Progect,   &School_Progect.directorOfStudiesWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   RForms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � Title$  directorOfStudiesWindow��5   	   $��496.466��6)   $��816.256��6:   .��5      � .+�5   
   � $��	0,0,0,438q�6   ���	#FF60B2E0.+�5	      �� $��
10,0,396,0q�6   $��
Завуч��6(   
�������$��16(�6K   $��
ExtraLight"�6Y   5
      �� 5   
   -   5        $	��438��5      $��0,28,0,0q�6"   $	��Top=�64   .@�5      �� $��
Уроки��6   .��5      � ���	#FFFCFCFC$	��400��6.   $	��659��6;   .+�5      �� $��10,10,272,363q�6   $u��oВыберите класс, предмет, введите дату и время.                            ��63   ���	#FF00040B$��13(�5   5   $��
ExtraLight"�6C   7  1System.Windows.Forms.Integration.WindowsFormsHost  5         
Background
 �����$
��Left=�6?   $	��348��6Z   $��	10,42,0,0q�6g   $	��Top=�6z   $	��186��6�      Child. 5      '   !System.Windows.Forms.DataGridView  -   5        dataGridView1��   ReadOnly .    AllowUserToAddRows .     
ScrollBars$
 Both=�5   p      BorderStyle$
 None=�6�      BackgroundColorU QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a#  System.Drawing.ColorConverter$ White 6�      SelectionMode$ FullRowSelect=�6�   "   System.Windows.Forms.Control	   Anchor$
	 Left=�6�   
   Dock$

 Fill=�6�   5        5      
 �����$
��Left=�6?   $	��348��6Z   $��
201,42,0,0q�6g   $	��Top=�6{   $	��186��6�   . 5        -   5        dataGridView2�� . $ FullRowSelect=�5   T    .  $
 Both=�6�   $
 None=�6�   $ White 6�   $
	 Left=�6�   $

 Fill=�6�   5      �� 5      -   5         ��Name$ tbDate��5      $��392,78,10,296q�6.   �� 5      -   5        $ tbTime��5      $��392,132,10,241q�6.   �� 5      $��392,42,10,327q�6   $��	Дата:��63   $��
ExtraLight"�6C   �� 5      $��392,164,10,212q�6   $��
ExtraLight"�64   $2��,Например: дд.мм.гггг ; 08:00��6L   ���	#FF4D60826s   �� 5      $��392,104,10,273q�6   $��
ExtraLight"�64   $��Время:��6L   �� 5      -   5        $��22��5      $��
ExtraLight"�6)   $	��Top=�6A   $��556,193,10,0q�6Y   $��Добавить��6o   ���	#FF00060D6�   5      5      �� 5      $��Меню��6   .��5       � ���	#FFFCFCFC.+�5!      &   System.Windows.Controls.Calendar  -   5          Name$ calendarFood��5!      $	��179��65   $��306,42,317,0q�6C   $	��Top=�6Y   6q   � 5"      $��10,42,511,65q�6   ���	#FFFDFAFA � RowDefinitions 5#      �� 5$      $
��253* �6,   �� 5%      $	��29* �6,   .+�5(      �� -   5         ��Name$ labelFirstDish1��5(       $��Первое блюдо��69   $
��Left=�6P   $��	10,10,0,0q�6k   $	��Top=�6~   $��13(�6�   $��
ExtraLight"�6�   �� 5)      -	   5        $ labelTwiseDish1��5)       $��Второе блюдо��69   $
��Left=�6P   $��	10,73,0,0q�6k   $	��Top=�6~   $��13(�6�   $��
ExtraLight"�6�   �� 5*      -
   5        $ labelDesert1��5*       $��Десерт��66   $
��Left=�6G   $��
10,136,0,0q�6b   $	��Top=�6v   $��13(�6�   $��
ExtraLight"�6�   �� 5+      -   5        $ labelDrink1��5+       $��Напиток��65   $
��Left=�6G   $��
11,199,0,0q�6b   $	��Top=�6v   $��13(�6�   $��
ExtraLight"�6�   �� 5,      -   5         ��Name$ comboBoxFirstDish��5,   #   $
��Left=�6>   $��	10,42,0,0q�6Y   $	��Top=�6l   $	��249��6�   �� 5-      -   5        $ comboBoxTwiseDish��5-   #   $
��Left=�6>   $��
10,105,0,0q�6Y   $	��Top=�6m   $	��247��6�   �� 5.      -   5        $ comboBoxDesert��5.   #   $
��Left=�6;   $��
11,168,0,0q�6V   $	��Top=�6j   $	��248��6�   �� 5/      -   5        $ comboBoxDrink��5/   #   $
��Left=�6:   $��
10,231,0,0q�6U   $	��Top=�6i   $	��247��6�   $��2��6�   50      �� 51      -   5         ��Name$ buttonAddFood��51      $��Добавить��64   $��665,329,23,33q�6G   6^   �� 52      $"��Добавить блюдо:��6   $��10,329,683,34q�66   $��13(�6M   $��
ExtraLight"�6[   �� 53      -   5        $ textBoxFoodName��53      $��292,329,138,33q�67    �� TextWrapping$
 Wrap=�6O   $/��)Введите названиеблюда��6c   $��13(�6�   �� 54      -   5        $ comboBoxFoodType��54      $��131,329,511,34q�69   $��13(�6Q   �� 55      -   5        $ buttonSaveSuggestion��55      $��Сохранить��6;   $
��Left=�6O   $��306,226,0,0q�6j   $	��Top=�6   $	��175��6�   $��40��6�   6�   �� 56      $��Текущее меню��6   $��92,10,595,0q�63   $	��Top=�6H   $��13(�6`   $��
ExtraLight"�6n   �� 57      $��Пожелания��6   $��603,10,58,0q�60   $	��Top=�6E   $��13(�6]   $��
ExtraLight"�6k     59      
 �����$��495,67,23,65q�6?   . 5:        -   5        dataGridView3�� .  $
 Both=�5:   `   $
 None=�6r   $ White 6�   $
	 Left=�6�   $

 Fill=�6�   5;      �� 5<      -   5        $ buttonFirst��5<      $��Первое��62   $��495,42,233,0q�6C   $	��Top=�6Y   6q   �� 5=      -   5        $ buttonSecond��5=      $��Второе��63   $��565,42,163,0q�6D   $	��Top=�6Z   6r   �� 5>      -   5        $ buttonDesert��5>      $��Десерт��63   $��635,42,93,0q�6D   $	��Top=�6Y   6q   �� 5?      -   5        $ buttonDrink��5?      $��Напиток��62   $��705,42,23,0q�6D   $	��Top=�6Y   6q   5A      5B      5C      5D      5E      