   M S B A M L   `   `   `  ���� A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  (    "Medkit.DialogsWindow.StatistDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:Medkit.DialogsWindow     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  StatistDialog��$	��500��$��525.362�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=�.���  � RowDefinitions �� $	��50* ��� $	��53* ��� $
��397* �.+��� ���	#FF388E3C�� ���	#FF388E3C�� $��0�� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Graph=�$��32��
�������$��32��$��Center=��� -    ��Name$ 
NameDialog��$+��%/Medkit;component/Fonts/#Roboto Black)�$��16(�$
��Left=�$��Center=�
�������$
��Bold"�.��Статистика�� $��1��$ 
Horizontal=�$��15,0,0,0q�.+��� -    $   MaterialDesignRaisedAccentButton#��[  $��50��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 	25 25 0 0��	 � ToolTip$(	 "Статистика за день��.���� $��За день��
�������$%��/Medkit;component/Fonts/#Roboto)��� -   #��[  $��50��$ 	25 25 0 0��$(	 "Статистика за день��$��4,0,0,0q�.���� $��За неделю��
�������$%��/Medkit;component/Fonts/#Roboto)��� -   #��[  $��50��$ 	25 25 0 0��$(	 "Статистика за день��$��5,0,0,0q�.���� $��За месяц��
�������$%��/Medkit;component/Fonts/#Roboto)�� -   
 �Name$	
 Day��$��2�� � ColumnDefinitions �� $
��358* ��� $
��167* � �� $	��51* ��� $	��39* ��� $	��63* ��� $	��63* ��� $	��64* ��� $
��117* �.+��� -    ��Name$ 	StatusBox��$��0��$��2��$y�Hidden=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Месяц�� & "MaterialDesignFloatingHintComboBox#��[    FloatingScale$
 0.90Q�$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��15,0q�$��42��$��Bottom=�.@��� 
 � Tag$ 1��.��Январь�� $ 2��.��Февраль�� $ 3��.��
Март�� $ 4��.��Апрель�� $ 5��.��Май�� $ 6��.��
Июнь�� $ 7��.��
Июль�� $ 8��.��Август�� $ 9��.��Сентябрь�� $ 10��.��Октябрь�� $ 11��.��Ноябрь�� $ 12��.��Декабрь�� $��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Bold"�$��0��$��Bottom=�$��28��$��10,0,0,0q�.��IGКоличество зарегестрированых приемов:�� -   $ RegPriem��$��1��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��1��$��Bottom=�$��28��$��10,0,0,0q�.��2 приема�� $��2��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Bold"�$��0��$��Bottom=�$��28��$��10,0,0,0q�.��;9Количество отменненых приемов:�� -	   $ BadPriem��$��2��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��1��$��Bottom=�$��28��$��10,0,0,0q�.��0 приемов�� $��3��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Bold"�$��0��$��Bottom=�$��28��$��10,0,0,0q�.��=;Количество завершенных приемов:�� -
   $ CancelPriem��$��3��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��1��$��Bottom=�$��28��$��10,0,0,0q�.��0 приемов�� $��4��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$
��Bold"�$��0��$��Bottom=�$��28��$��10,0,0,0q�.��Выручка:�� -   $	 Sum��$��4��$%��/Medkit;component/Fonts/#Roboto)�$��16(�$��1��$��Bottom=�$��28��$��10,0,0,0q�.��0 рублей�� $��5��$��2��$��Bottom=�$��84��.+��� -    ��Name$ AcceptButton�� " MaterialDesignRaisedDarkButton#��[ $��
10,0,10,10q�$%��/Medkit;component/Fonts/#Roboto)�$��16(�
�������.��'%Экспортировать в Excel��  �� IsCancel . #��[ $��
10,0,10,10q�$��16(�$%��/Medkit;component/Fonts/#Roboto)�
�������.��Закрыть