   M S B A M L   `   `   `  ���� A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  *    $Medkit.DialogsWindow.AddDoctorDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:Medkit.DialogsWindow     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  AddDoctorDialog��$	��500��$	��500�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=�.���  � ColumnDefinitions �� ��  � RowDefinitions �� $	��44* ��� $	��49* ��� $	��49* ��� $	��49* ��� $	��49* ��� $	��49* ��� $	��49* ��� $	��75* ��� $	��87* �.+��� ���	#FF388E3C$��2���� $��0�� �� Orientation$ 
Horizontal=�$��2��.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
PencilPlus=�$��32��
�������$��32��$��Center=��� -    ��Name$ TitleDialog��$+��%/Medkit;component/Fonts/#Roboto Black)�$��16(�$
��Left=�$��Center=�
�������$
��Bold"�.��Новый врач�� -   	 ��Name$	 	FamDoctor��
 �� 	MaxLength$	
 100��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия врача��   FloatingScale$
 0.90Q� %  !MaterialDesignFloatingHintTextBox#��[  $��1��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��2���� -   $	 
NameDoctor��$	
 100��$ Имя врача��$
 0.90Q�#��[  $��2��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��2���� -   $	 	SenDoctor��$	
 100��$! Отчество врача��$
 0.90Q�#��[  $��3��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��2���� $ 
Horizontal=�$��4��$��2��.+��� -    ��Name$ SpecDoctorBox�� �� 
IsEditable . $ Направление�� & "MaterialDesignFloatingHintComboBox#��[  �� DisplayMemberPath$	 Spl��$
 0.90Q� �� SelectedValuePath$	 Num��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$��15,4,0,4q�$��Center=�$	��345���� -    � ToolTip$< 6Добавить новую специальность��
����������	#FF388E3C���	#FF388E3C$��Center=�$��Bottom=�$��15,0,0,5q���0  *MaterialDesignThemes.Wpf.PackIconExtension  *PlusBoxMultiple+�� $��5��$ 
Horizontal=�$
��Left=�$��Center=�$��0,2,0,3q�$��44��$	��286��$��2��.+��� $%��/Medkit;component/Fonts/#Roboto)�$
��Bold"�$��16(�$��10,0,0,0q�$��Bottom=�.��Время приема:�� $%��/Medkit;component/Fonts/#Roboto)�$
��Bold"�$��16(�$��10,0,0,0q�$��Bottom=�.��с�� -   $	 	StartTime��$ час��$n hНачало приема устанавливается в диапазоне от 8 до 16 часов��$
 2��$
 0.90Q�#��[  $��3��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$��	10,0,15,0q��� $%��/Medkit;component/Fonts/#Roboto)�$
��Bold"�$��16(�$��0q�$��Bottom=�.��до�� -	   $	 EndTime��$ час��$t nОкончание приема устанавливается в диапазоне от 9 до 18 часов��$
 2��$
 0.90Q�#��[  $��3��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$��	10,0,15,0q��� $��8��$��2��$��Bottom=�$��84��.+��� -
    ��Name$ AcceptButton�� " MaterialDesignRaisedDarkButton#��[ $��
10,0,10,10q�$%��/Medkit;component/Fonts/#Roboto)�$��16(�
�������.��Добавить��  �� IsCancel . #��[ $��
10,0,10,10q�$��16(�$%��/Medkit;component/Fonts/#Roboto)�
�������.��Отмена�� -   $	 CabFas��$ Кабинет��$
 3��$
 0.90Q�#��[  $��6��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��0���� -   $	 Price��$ Цена приема��$
 5��$
 0.90Q�#��[  $��6��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��1��'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ 	SnackInfo��$��7��$��2��$��0,0,0,10q�   MessageQueue 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  �� -   $ 
WarningMsg��$y�Hidden=����	#FFD42626$��7��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��5,0,0,0q�$��Bottom=�$��27��.��%#Заполните все поля!�� -    ��Name$ 	ShadowEff��$y�Hidden=����	#CD000000$��2��$��9��