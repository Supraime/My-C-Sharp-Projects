   M S B A M L   `   `   `  ����A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  5   	   "    Medkit.DialogsWindow.UserAdd   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Medkit.DialogsWindow     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  UserAdd��5	   	   $	��500��6   $	��500��6&    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterOwner=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��44* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $	��54* �6   �� 5      $	��44* �6   �� 5      $	��75* �6   �� 5      $	��87* �6   .+�5   
   �� ���	#FF388E3C$��2��6%   6;   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $��2��6;   .+�5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
PencilPlus=�5!      $��32��5"      
�������$��32��5$      $��Center=�5%      �� 5&      -   5         ��Name$ TitleDialog��5&      $+��%/Medkit;component/Fonts/#Roboto Black)�6*   $��16(�6]   $
��Left=�6k   $��Center=�6�   
�������$
��Bold"�6�   .��6�   %#Новый пользователь6�   5'      �� 5(   
   -   5        	 ��Name$	 	LoginUser��5)      
 �� 	MaxLength$	
 100��5*      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��5+         FloatingScale$
 0.90Q�5,       %  !MaterialDesignFloatingHintTextBox#��[  5-      $��1��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��2��6�   �� 5.   
   -   5        $	 UsernameBox��5/      $	
 100��50      $( "Имя учетной записи��53      $
 0.90Q�54      #��[  55      $��2��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��2��6�   �� 56   
   -   5         ��Name$ 	StatusBox��59      $��3��57      $��2��58      $ Статус��5:       & "MaterialDesignFloatingHintComboBox#��[ 5;      $
 0.90Q�5<      $%��/Medkit;component/Fonts/#Roboto)�6<   $��14(�6i   $
��15,4q�6w   $��41��6�   .@�5=      �� 
 � Tag$ Сотрудник��6   .��6+   Пользователь69   �� 5>      $  Администратор��6   .��6/   Администратор6>   5?      �� 5@   
   $ 
Horizontal=�6   $��4��6.   $��2��6;   .+�5A      �� -   5        $	 Password��5B      $	
 100��5C       � ToolTip$� �Пароль должен состоять из не менее 8 символов и содержать в себе латинские буквы и цифры��5D      $ Пароль��5E      $
 0.90Q�5F      #��[  5G      $��2��6L   $%��/Medkit;component/Fonts/#Roboto)�6Y   $��14(�6�   $
��15,0q�6�   $	��350��6�   �� 5H      -   5        $- 'Сгенерировать пароль��5J      
����������	#FF388E3C���	#FF388E3C$��Center=�5O      $��Bottom=�6.   $��0,0,0,5q�6I   ��5I      0  *MaterialDesignThemes.Wpf.PackIconExtension  *Brain+5O   I   5P      �� 5Q   
   -   5        $	 RepeatPassword��5R      $	
 100��5S      $% Повторите пароль��5T      $
 0.90Q�5U      #��[  5V      $��5��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $��15,0,0,0q�6�   $��2��6�   $	��350��6�   $
��Left=�6�   $��Bottom=�6�   $��44��6�   �� 5W   
   $��8��6   $��2��6"   $��Bottom=�66   $��84��6Q   .+�5X      �� -   5         ��Name$ AcceptButton��5X       " MaterialDesignRaisedDarkButton#��[ 6H   $��
10,0,10,10q�6�   $%��/Medkit;component/Fonts/#Roboto)�6�   $��16(�6�   
�������.��6�   Добавить6�   �� 5Y       �� IsCancel . #��[ 6%   $��
10,0,10,10q�6]   $��16(�6q   $%��/Medkit;component/Fonts/#Roboto)�6   
�������.��6�   Отмена6�   5Z      �� 5[   
   -	   5        $ 
WarningMsg��5[   8   $y�Hidden=�6   $��2��6$   ���	#FFD42626$��7��6c   $%��/Medkit;component/Fonts/#Roboto)�6p   $��16(�6�   $��5,0,0,0q�6�   $��Bottom=�6�   $��27��6�   .��6�   %#Заполните все поля!6�   5\      5]      