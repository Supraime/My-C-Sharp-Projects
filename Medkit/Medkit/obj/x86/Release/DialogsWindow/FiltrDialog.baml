   M S B A M L   `   `   `  ���� A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  &     Medkit.DialogsWindow.FiltrDialog   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:Medkit.DialogsWindow     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  FiltrDialog��$	��500��$	��500�� � WindowStartupLocation$ CenterOwner=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�.���  � ColumnDefinitions �� $
��105* ��� $
��145* ��� $	��86* ��� $
��164* � � RowDefinitions �� $	��47* ��� $	��34* ��� $	��44* ��� $	��38* ��� $
��243* ��� $	��94* �.+��� ���	#FF388E3C$��4���� $��0�� �� Orientation$ 
Horizontal=�$��4��.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Filter=�$��32��
�������$��32��$��Center=��� -    ��Name$ TitleDialog��$+��%/Medkit;component/Fonts/#Roboto Black)�$��16(�$
��Left=�$��Center=�
�������$
��Bold"�.��Фильтры�� $��1��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��Bold"�$��Bottom=�$��25��$��15,0,0,0q�.��По датеd� -   	 d�Name$	 	DateCheck��$��1��$��1�� (  $MaterialDesignSwitchDarkToggleButton#��[  
 d� 	IsChecked$
 FalseY�$
��Left=�$��Bottom=�$��0,0,0,5q�$��18��$��34���� $��1��$��2��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��Bold"�$��Bottom=�$��25��.��По месяцуd� -   $	 
MonthCheck��$��1��$��3��#��[  $
 FalseY�$
��Left=�$��Bottom=�$��0,0,0,5q�$��18��$��34��(  "System.Windows.Controls.DatePicker  -     Name$ DateDay��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фильтр даты�� � Language$ ru-RU�{�.  $��2�� ( $MaterialDesignFloatingHintDatePicker#��[    FloatingScale$
 0.90Q�$
��15,0q�$��2��$��Bottom=�$%��/Medkit;component/Fonts/#Roboto)�$��14(�$��38���� -    ��Name$ 	StatusBox��$��2��$��2��{�.   �� 
IsEditable .  $ Фильтр месяца�� & "MaterialDesignFloatingHintComboBox#��[ $
 0.90Q�$%��/Medkit;component/Fonts/#Roboto)�$��14(�$��0,0,15,0q�$��42��$��Bottom=�$��Right=�$	��229��$��2��.@��� 
 � Tag$ 1��.��Январь�� $ 2��.��Февраль�� $ 3��.��
Март�� $ 4��.��Апрель�� $ 5��.��Май�� $ 6��.��
Июнь�� $ 7��.��
Июль�� $ 8��.��Август�� $ 9��.��Сентябрь�� $ 10��.��Октябрь�� $ 11��.��Ноябрь�� $ 12��.��Декабрь�� $��3��$��0��$%��/Medkit;component/Fonts/#Roboto)�$��14(�$
��Bold"�$��Bottom=�$��25��$��15,0,0,0q�.��По времениd� -   $	 	TimeCheck��$��3��$��1��#��[  $
 FalseY�$
��Left=�$��Bottom=�$��0,0,0,5q�$��18��$��34��� -    �Name$ Panel�� � Orientation$ 
Horizontal=�$��0q�$��4��$��4��.+�	� -    	�Name$ Time0��   MaterialDesignTabRadioButton#��[ $��4q�$
 FalseY�$
��8:00��	� -	   $ Time1��#��[ $��4q�$
 FalseY�$
��8:30��	� -
   $ Time2��#��[ $��4q�$
 FalseY�$
��9:00��	� -   $ Time3��#��[ $��4q�$
 FalseY�$
��9:30��	� -   $ Time4��#��[ $��4q�$
 FalseY�$��10:00��	� -   $ Time5��#��[ $��4q�$
 FalseY�$��10:30��	� -   $ Time6��#��[ $��4q�$
 FalseY�$��11:00��	� -   $ Time7��#��[ $��4q�$
 FalseY�$��11:30��	� -   $ Time8��#��[ $��4q�$
 FalseY�$��12:00��	� -   $ Time9��#��[ $��4q�$
 FalseY�$��12:30��	� -   $ Time10��#��[ $��4q�$
 FalseY�$��13:30��	� -   $ Time11��#��[ $��4q�$
 FalseY�$��14:00��	� -   $ Time12��#��[ $��4q�$
 FalseY�$��14:30��	� -   $ Time13��#��[ $��4q�$
 FalseY�$��15:00��	� -   $ Time14��#��[ $��4q�$
 FalseY�$��15:30��	� -   $ Time15��#��[ $��4q�$
 FalseY�$��16:00��	� -   $ Time16��#��[ $��4q�$
 FalseY�$��16:30��	� -   $ Time17��#��[ $��4q�$
 FalseY�$��17:00��	� -   $ Time18��#��[ $��4q�$
 FalseY�$��17:30���� $��5��$��4��$��Bottom=�$��84��.+���  �� IsCancel .  " MaterialDesignRaisedDarkButton#��[ $��
10,0,10,10q�$��16(�$%��/Medkit;component/Fonts/#Roboto)�
�������.��Применить�� -    ��Name$ AcceptButton��#��[ $��
10,0,10,10q�$%��/Medkit;component/Fonts/#Roboto)�$��16(�
�������.��!Сбросить фильтры