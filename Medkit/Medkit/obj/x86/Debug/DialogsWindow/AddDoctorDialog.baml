   M S B A M L   `   `   `  ����A  =Medkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Medkit.DialogsWindowMedkit.DialogsWindow  5   	   *    $Medkit.DialogsWindow.AddDoctorDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Medkit.DialogsWindow     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  AddDoctorDialog��5	   	   $	��500��6!   $	��500��6.    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterOwner=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��44* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $	��49* �6   �� 5      $	��75* �6   �� 5      $	��87* �6   .+�5   
   �� ���	#FF388E3C$��2��6%   �� 5    
   $��0��6    �� Orientation$ 
Horizontal=�6"   $��2��6;   .+�5!      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
PencilPlus=�5"      $��32��5#      
�������$��32��5%      $��Center=�5&      �� 5'      -   5         ��Name$ TitleDialog��5'      $+��%/Medkit;component/Fonts/#Roboto Black)�6*   $��16(�6]   $
��Left=�6k   $��Center=�6�   
�������$
��Bold"�6�   .��6�   Новый врач6�   5(      �� 5)   
   -   5        	 ��Name$	 	FamDoctor��5*      
 �� 	MaxLength$	
 100��5.      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия врача��5/         FloatingScale$
 0.90Q�50       %  !MaterialDesignFloatingHintTextBox#��[  51      $��1��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��2��6�   �� 52   
   -   5        $	 
NameDoctor��53      $	
 100��54      $ Имя врача��58      $
 0.90Q�59      #��[  5:      $��2��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��2��6�   �� 5;   
   -   5        $	 	SenDoctor��5<      $	
 100��5=      $! Отчество врача��5A      $
 0.90Q�5B      #��[  5C      $��3��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��2��6�   �� 5D   
   $ 
Horizontal=�6   $��4��6.   $��2��6;   .+�5E      �� -   5         ��Name$ SpecDoctorBox��5F       �� 
IsEditable . $ Направление��5H       & "MaterialDesignFloatingHintComboBox#��[ 5K       �� DisplayMemberPath$	 Spl��5L      $
 0.90Q�5M       �� SelectedValuePath$	 Num��5N      $%��/Medkit;component/Fonts/#Roboto)�6)   $��14(�6V   $��15,4,0,4q�6d   $��Center=�6v   $	��345��6�   �� 5O      -   5         � ToolTip$< 6Добавить новую специальность��5Q      
����������	#FF388E3C���	#FF388E3C$��Center=�5V      $��Bottom=�6.   $��15,0,0,5q�6I   ��5P      0  *MaterialDesignThemes.Wpf.PackIconExtension  *PlusBoxMultiple+5V   I   5W      �� 5X   
   $��5��6   $ 
Horizontal=�6#   $
��Left=�6<   $��Center=�6W   $��0,2,0,3q�6r   $��44��6�   $	��286��6�   $��2��6�   .+�5Y      �� $%��/Medkit;component/Fonts/#Roboto)�6   $
��Bold"�6A   $��16(�6S   $��10,0,0,0q�6a   $��Bottom=�6s   .��6�   Время приема:6�   �� 5Z      $%��/Medkit;component/Fonts/#Roboto)�6   $
��Bold"�6A   $��16(�6S   $��10,0,0,0q�6a   $��Bottom=�6s   .��6�   с6�   �� 5[      -   5        $	 	StartTime��5\      $ час��5]      $n hНачало приема устанавливается в диапазоне от 8 до 16 часов��5^      $
 2��5`      $
 0.90Q�5a      #��[  5b      $��3��6L   $%��/Medkit;component/Fonts/#Roboto)�6Y   $��14(�6�   $��	10,0,15,0q�6�   6�   �� 5c      $%��/Medkit;component/Fonts/#Roboto)�6   $
��Bold"�6A   $��16(�6S   $��0q�6a   $��Bottom=�6l   .��6�   до6�   �� 5d      -	   5        $	 EndTime��5e      $ час��5f      $t nОкончание приема устанавливается в диапазоне от 9 до 18 часов��5g      $
 2��5i      $
 0.90Q�5k      #��[  5l      $��3��6L   $%��/Medkit;component/Fonts/#Roboto)�6Y   $��14(�6�   $��	10,0,15,0q�6�   5m      �� 5n   
   $��8��6   $��2��6"   $��Bottom=�66   $��84��6Q   .+�5o      �� -
   5         ��Name$ AcceptButton��5o       " MaterialDesignRaisedDarkButton#��[ 6,   $��
10,0,10,10q�6d   $%��/Medkit;component/Fonts/#Roboto)�6x   $��16(�6�   
�������.��6�   Добавить6�   �� 5p       �� IsCancel . #��[ 6%   $��
10,0,10,10q�6]   $��16(�6q   $%��/Medkit;component/Fonts/#Roboto)�6   
�������.��6�   Отмена6�   5q      �� 5r   
   -   5        $	 CabFas��5s      $ Кабинет��5t      $
 3��5w      $
 0.90Q�5x      #��[  5y      $��6��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��0��6�   �� 5z   
   -   5        $	 Price��5{      $ Цена приема��5|      $
 5��5      $
 0.90Q�5�      #��[  5�      $��6��6H   $%��/Medkit;component/Fonts/#Roboto)�6U   $��14(�6�   $
��15,0q�6�   $��1��6�   '  !MaterialDesignThemes.Wpf.Snackbar  5�   
   -   5          Name$ 	SnackInfo��5�   D   $��7��6"   $��2��6/   $��0,0,0,10q�6�      MessageQueue 6W   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  6�   �� 5�   
   -   5        $ 
WarningMsg��5�   $   $y�Hidden=�6   ���	#FFD42626$��7��6O   $%��/Medkit;component/Fonts/#Roboto)�6\   $��16(�6�   $��5,0,0,0q�6�   $��Bottom=�6�   $��27��6�   .��6�   %#Заполните все поля!6�   �� 5�   
   -   5         ��Name$ 	ShadowEff��5�   (   $y�Hidden=�6   ���	#CD000000$��2��6L   $��9��6`   6s   5�      5�      