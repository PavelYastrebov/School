   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.0.0.6, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    School Progect   School_Progect.AddEvent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$  	AddEvent1��5       � Title$% Добавить событие��5   	   $��312.779��6"   $��456.776��63   .��5      � $��0,0,2,0q�6   ���	#FFFCFCFC.+�5   
   � $
��Left=�6   $��37��6*   $	��Top=�66   $	��447��6N   ���	#FF41B1E1.+�5      �� $t��nДобавление нового предстоящего события на доску объявлений��6   $��Right=�6Y   $��0,10,6,0q�6u   $	��Top=�6�   $��14(�6�   
�������6�   5	      �� 5
   
   $E��?*Все поля обязательны к заполнению��6   $
��Left=�6=   $��
10,257,0,0q�6X   $	��Top=�6l    J� RenderTransformOrigin$ 0,-1.062&�6�   $��26��6�   ���	#FFFCFCFC���	#FF110101$��
ExtraLight"�6�   �� 5   
   $��*Заголовок:��6   $
��Left=�6&   $��	10,49,0,0q�6A   $	��Top=�6T   $��
ExtraLight"�6l   �� 5   
   -   5         ��Name$ textBoxLabel��5      $
��Left=�6(   $��23��6C   $��	96,49,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��341��6�   �� 5   
   $��*Содержание:��6   $
��Left=�6'   $��	10,77,0,0q�6B   $	��Top=�6U   $��
ExtraLight"�6m   �� 5   
   -   5        $ textBoxContent��5      $
��Left=�6*   $	��117��6E   $��
10,106,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $	��427��6�   �� 5   
   $.��(*Дата удаления записи:��6   $
��Left=�61   $��
10,226,0,0q�6L   $	��Top=�6`   $ -1,0.188&�6x   $��
ExtraLight"�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datePickerEnd��5      $
��Left=�6,   $��151,228,0,0q�6G   $	��Top=�6\      SelectedDateFormat$ Short=�6t   �� 5   
   -   5         ��Name$ 
buttonSave��5      $��Сохранить��6%   $
��Left=�69   $��362,229,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5   
   -   5        $ buttonCancel��5      $��Отмена��6'   $
��Left=�68   $��272,229,0,0q�6S   $	��Top=�6h   $��75��6�   6�   5      5      