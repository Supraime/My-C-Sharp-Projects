   M S B A M L   `   `   `  ���� A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  $    Medkit.DialogsWindow.CheckSpec   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:Medkit.DialogsWindow     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  	CheckSpec��$	��500��$	��500�� � WindowStartupLocation$ CenterOwner=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�.���  � RowDefinitions �� $	��46* ��� $
��317* ��� $	��45* ��� $	��92* �.+��� ���	#FF388E3C$��0q��� $��0�� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ TextBoxPlus=�$��32��
�������$��32��$��Center=��� $+��%/Medkit;component/Fonts/#Roboto Black)�$��16(�$
��Left=�$��Center=�
�������.��Специальности&   System.Windows.Controls.DataGrid  -     Name$ dataWork��$��5,8,5,0q�   CanUserSortColumns . 	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 
   CanUserDeleteRows
 .  $   HorizontalScrollBarVisibility$ Disabled=�-  'MaterialDesignThemes.Wpf.DataGridAssist   ColumnHeaderPadding$ 8q�   CanUserAddRows .  $%��/Medkit;component/Fonts/#Roboto)� � ToolTip$W QКликните по строке для подробной информации��$��14(�$��1������  � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%�   '        7 �� 8   "  .���  � �� �	#FF388E3C��  � ��
 �������  � ��$+ %/Medkit;component/Fonts/#Roboto Black)���  � ��$ 16(�   RowDetailsTemplate �� .R�]� 
�������.+�� $
��0,10q� � ColumnDefinitions �� $
��Auto ��� $��* � �� $
��Auto �.+��� -    "  MaterialDesignRaisedDarkButton#��[  $	��150��$��0��$��0��
�������$
��Left=�$��10,0,0,0q�����  �� Path$ id�.��Редактировать��  ��Name$ 	TalonWord��-   #��[  $	��150��
�������$��0��$��1��$��Right=�$
��10,0q����� $ id�.��Удалить'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ 	SnackInfo��$��2��$��0��$��106,0,106,1q�$��0��$	��288��   MessageQueue 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  �� $��3��$��Bottom=�$��84��.+��� -   $ AcceptButton��#��[  $��
10,0,10,10q�$%��/Medkit;component/Fonts/#Roboto)�$��16(�
�������.��-+Добавить специальность��  �� IsCancel . #��[  $��
10,0,10,10q�$��16(�$%��/Medkit;component/Fonts/#Roboto)�
�������.��Закрыть�� -    ��Name$ Shadow��$y�Hidden=����	#B8000000$��4��