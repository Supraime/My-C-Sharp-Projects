   M S B A M L   `   `   `  ���� A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  %    Medkit.DialogsWindow.AddSpecial   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:Medkit.DialogsWindow     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  
AddSpecial��$��206.128��$	��500�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=�.���  � RowDefinitions �� $	��37* ��� $	��48* ��� $	��37* ��� $	��84* �.+��� ���	#FF388E3C�� $��0�� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
PencilPlus=�$��32��
�������$��32��$��Center=��� -    ��Name$ NameBox��$+��%/Medkit;component/Fonts/#Roboto Black)�$��16(�$
��Left=�$��Center=�
�������$
��Bold"�.��'%Новая специальность�� -    ��Name$ SpecNameBox��)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$1	 +Название специальности��
   FloatingScale$

 0.90Q� %  !MaterialDesignFloatingHintTextBox#��[  $��1��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$	��Top=��� -   $ 
WarningMsg��$y�Hidden=����	#FFD42626$��2��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��5,0,0,0q�$��Bottom=�$��27��.��!Введите название�� $��3��$��Bottom=�$��84��.+��� -    ��Name$ AddSpec�� " MaterialDesignRaisedDarkButton#��[ $��
10,0,10,10q�$%��/Medkit;component/Fonts/#Roboto)�$��16(�.��Добавить��  �� IsCancel . #��[ $��
10,0,10,10q�$��16(�$%��/Medkit;component/Fonts/#Roboto)�.��Отмена