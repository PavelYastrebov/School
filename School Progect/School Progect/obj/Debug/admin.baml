   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5   	   H DMahApps.Metro, Version=1.0.0.6, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	    School Progect   School_Progect.admin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � Title$   Администрация��5   	   $	��524��6   $��826.872��6,   .��5      � .+�5   
   � $
��Left=�6   $	��407��6*   
�������$��0,0,0,2q�6I   .+�5	      7  1System.Windows.Forms.Integration.WindowsFormsHost  $��10,70,10,10q�6      Child. 5
      '   !System.Windows.Forms.DataGridView  -   5        dataGridView1��   AllowUserToResizeRows .     ReadOnly .    
ScrollBars$
 Both=�5
   g      BorderStyle$
 None=�6y      BackgroundColorU QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a#  System.Drawing.ColorConverter$ White 6�      SelectionMode$ FullRowSelect=�6�   "   System.Windows.Forms.Control   Anchor$
 Left=�6�   	   Dock$
	 Fill=�6  5      � 5      $��38��6   $	��Top=�6   ���	#FF41B1E1$��	0,0,-76,0q�6N   .+�5      �� $M��GВсе зарегистрированные школы в городе:��6   $
��Left=�6I   $��	10,10,0,0q�6d   $	��Top=�6w   $��14(�6�   $��
ExtraLight"�6�   
�������6�   5      5      � 5   
   $��	406,0,6,2q�6   
�������.+�5      �� -   5        
 ��Name$
 tbNumber��5      $
��Left=�6(   $��26��6C   $��
141,71,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��256��6�   �� 5      -   5        $
 tbName��5      $
��Left=�6&   $��26��6A   $��141,102,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��256��6�   �� 5      $��
Город��6   $
��Left=�6$   $��
20,137,0,0q�6?   $	��Top=�6S   $��14(�6k   $��
ExtraLight"�6y   �� 5      -   5         ��Name$ cbCity��5      $
��Left=�6'   $��141,133,0,0q�6B   $	��Top=�6W   $	��256��6o    �� SelectedIndex$ 0��6{   $��26��6�   .@�5      �� $��Харьков��6   �� 5      $��Киев��6   �� 5      $��Луганск��6   �� 5      $��Одесса��6   �� 5      $��Донецк��6   5      �� 5      -   5        $
 tbPhone��5      $
��Left=�6'   $��26��6B   $��141,195,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��256��6�   �� 5      -   5        $
 	tbAddress��5      $
��Left=�6)   $��26��6D   $��141,164,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��256��6�   �� 5      -   5         ��Name$ 
bAddSchool��5      $!��Добавить школу��6)   $
��Left=�6B   $��260,226,0,0q�6]   $	��Top=�6r   $	��137��6�   6�   �� 5      $
��Left=�6   $��
33,318,0,0q�6/   $	��Top=�6C   5      � 5    
   $��38��6   $��	406,0,6,0q�6   $	��Top=�6.   ���	#FF41B1E1.+�5!      �� $(��"Регистрация школы:��6   $
��Left=�61   $��	10,10,0,0q�6L   $	��Top=�6_   
�������$��14(�6�   $��
ExtraLight"�6�   5"      �� 5#   
   $��
Номер��6   $
��Left=�6    $��
427,74,0,0q�6;   $	��Top=�6O    J� RenderTransformOrigin$ 0.605,2.111&�6g   $��14(�6�   $��
ExtraLight"�6�   �� 5$   
   $��Телефон��6   $
��Left=�6"   $��427,199,0,0q�6=   $	��Top=�6R   $��14(�6j   $��
ExtraLight"�6x   �� 5%   
   $��
Адрес��6   $
��Left=�6    $��427,168,0,0q�6;   $	��Top=�6P   $ 1.669,0.393&�6h   $��14(�6�   $��
ExtraLight"�6�   �� 5&   
   $��Название��6   $
��Left=�6#   $��427,105,0,0q�6>   $	��Top=�6S   $��14(�6k   $��
ExtraLight"�6y   5'      5(      