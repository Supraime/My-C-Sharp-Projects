   M S B A M L   `   `   `  ����A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  5   	   $    Medkit.DialogsWindow.CheckSpec   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Medkit.DialogsWindow     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6:   -   5          � Title$  	CheckSpec��5   	   $	��500��6   $	��500��6(    � WindowStartupLocation$ CenterOwner=�5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��46* �6   �� 5      $
��317* �6   �� 5      $	��45* �6   �� 5      $	��92* �6   .+�5   
   �� ���	#FF388E3C$��0q�6%   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ TextBoxPlus=�5      $��32��5      
�������$��32��5      $��Center=�5      �� 5      $+��%/Medkit;component/Fonts/#Roboto Black)�6   $��16(�6G   $
��Left=�6U   $��Center=�6p   
�������.��6�   Специальности6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataWork��5       $��5,8,5,0q�5         CanUserSortColumns . 	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 5#      
   CanUserDeleteRows
 .  $   HorizontalScrollBarVisibility$ Disabled=�5%      -  'MaterialDesignThemes.Wpf.DataGridAssist   ColumnHeaderPadding$ 8q�5&         CanUserAddRows .  $%��/Medkit;component/Fonts/#Roboto)�5'   &    � ToolTip$W QКликните по строке для подробной информации��5(      $��14(�6E   $��1��5)      ��5!      ��  � 	Resources 5*      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%�   '        7 �� 5+      8   "  6Q   .�5,      ��  � �� �	#FF388E3C63   �� 5-       � ��
 �����63   �� 5.       � ��$+ %/Medkit;component/Fonts/#Roboto Black)�63   �� 5/       � ��$ 16(�61   50      51         RowDetailsTemplate 52      �� 53      .R�54      ]� 
�������.+�55      � $
��0,10q�6    � ColumnDefinitions 56      �� 57   "   $
��Auto �63   �� 58   "   $��* �63    5:      �� 5;   "   $
��Auto �60   .+�5=      �� -   5         "  MaterialDesignRaisedDarkButton#��[  5>   -   $	��150��5?   -   $��0��5@   !   $��0��5A   !   
�������$
��Left=�5D   -   $��10,0,0,0q�5E   R   ��6-   ��  �� Path$ id�.��6d   Редактировать5G      �� 5H       ��Name$ 	TalonWord��5M   -   -   5        #��[  5I   -   $	��150��5J   -   
�������$��0��5L   !   $��1��5N   !   $��Right=�5O   -   $
��10,0q�5Q   R   ��6-   �� $ id�.��6`   Удалить5S      5T      5U      5V      5X      '  !MaterialDesignThemes.Wpf.Snackbar  5Y   
   -   5          Name$ 	SnackInfo��5Y   ?   $��2��6"   $��0��6/   $��106,0,106,1q�6   $��0��6�   $	��288��6�      MessageQueue 6R   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  6�   �� 5Z   
   $��3��6   $��Bottom=�6"   $��84��6=   .+�5[      �� -   5        $ AcceptButton��5[   1   #��[  6G   $��
10,0,10,10q�6   $%��/Medkit;component/Fonts/#Roboto)�6�   $��16(�6�   
�������.��6�   -+Добавить специальность6�   �� 5\       �� IsCancel . #��[  6%   $��
10,0,10,10q�6]   $��16(�6q   $%��/Medkit;component/Fonts/#Roboto)�6   
�������.��6�   Закрыть6�   5]      �� 5^   
   -   5         ��Name$ Shadow��5^   (   $y�Hidden=�6   ���	#B8000000$��4��6I   5_      5`      