   M S B A M L   `   `   `  ����A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MedkitMedkit  5   	       Medkit.CustomMessageBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	    localclr-namespace:Medkit  5   	   -   5          � Title$  CustomMessageBox��5	   	   $	��145��6"   $	��500��6/    � WindowStyle$
 None=�6;    � WindowStartupLocation$ CenterOwner=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      � .+�5   
   �� $��40��6   $	��Top=�6    ���	#FF388E3C6K   � 5   
   $��40��6   $	��Top=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   $��10,0,0,0q�6M   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ MessageAlert=�6*   
�������$��Center=�6Q   $��Center=�6l   �� 5      -   5         ��Name$ 
titleLabel��5      $+��%/Medkit;component/Fonts/#Roboto Black)�6,   $��16(�6_   $��Center=�6m   $
��Left=�6�   
�������.��6�   
MessageBox6�   5      5      � 5   
   -   5         �Name$ 	adaptMenu��5      $	��500��6"   $��0q�6.   $��Center=�69   $��Bottom=�6V   $	��115��6q    � RowDefinitions 5      �� 5      $	��12* �6    �� 5      $	��11* �6    	 � ColumnDefinitions	 5      �� 5      $	��19* �6#   �� 5      $	��12* �6#   �� 5      $	��19* �6#   .+�5      �� -   5        $ messageLabel��5      $��Center=�6*   $��Center=�6G   $%��/Medkit;component/Fonts/#Roboto)�6b   $��14(�6�   $��0,23,0,0q�6�   $��3��6�   .��6�   MessageText6�   �� 5       -   5        
 ��Name$
 buttonOk��5        �� IsCancel . $y�Hidden=�67   $
��Ок��6K   
�������$��Center=�6k   $��0q�6�   $��Center=�6�   $	��102��6�   $%��/Medkit;component/Fonts/#Roboto)�6�   $��1��6�   $��1��6�    "  MaterialDesignRaisedDarkButton#��[  6  $��16(�6<  �� 5!      -   5        $
 	buttonYes��5!       �� 	IsDefault . $y�Hidden=�6Q   $��1��6e   $��Подтвердить��6r   $%��/Medkit;component/Fonts/#Roboto)�6�   
�������$��0q�6�   $��Center=�6�   #��[  6�   $��16(�6(  68  �� 5"      -   5        $
 buttonNo��5"       . $y�Hidden=�68   $��1��6L   $��3��6Y   $��Отмена��6i   $%��/Medkit;component/Fonts/#Roboto)�6z   
�������$��0q�6�   $��Center=�6�   #��[  6�   $��16(�6  6*  5#      5$      5%      